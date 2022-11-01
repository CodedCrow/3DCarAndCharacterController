using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] GameObject Camera;
    private Vector2 MouseVector;
    private float yRotation;
    [SerializeField] float MouseSensitivity;

    private Vector3 InputVector;
    [SerializeField] CharacterController CharControl;
    [SerializeField] float Speed;
    private float YVelocity;
    [SerializeField] private float JumpFloaty; //max time the jump button can be held for max jump height

    private float JumpTimer;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        //camera
        MouseVector.x = Input.GetAxis("Mouse X") * Time.deltaTime * MouseSensitivity;
        MouseVector.y = Input.GetAxis("Mouse Y") * Time.deltaTime * MouseSensitivity;

        yRotation -= MouseVector.y;
        yRotation = Mathf.Clamp(yRotation, -90f, 90f);

        Camera.transform.localRotation = Quaternion.Euler(yRotation, 0f, 0f);
        transform.Rotate(Vector3.up * MouseVector.x);

        //body
        InputVector.x = Input.GetAxis("Horizontal");
        InputVector.z = Input.GetAxis("Vertical");
        if(Input.GetButtonDown("Jump") && CharControl.isGrounded)
        {
            YVelocity = 2f;
            JumpTimer = 0.15f;
        }
        else if (Input.GetButton("Jump") && JumpTimer >= 0)
        {
            YVelocity -= 0.98f * Time.deltaTime;
            JumpTimer -= Time.deltaTime;
        }
        else if (!CharControl.isGrounded)
        {
            YVelocity -= 9.81f * Time.deltaTime;
        }
        else
        {
            YVelocity = -1f;
        }


        Vector3 MoveVector = transform.right * InputVector.x + transform.up * YVelocity + transform.forward * InputVector.z;

        CharControl.Move(MoveVector * Speed * Time.deltaTime);
    }

}
