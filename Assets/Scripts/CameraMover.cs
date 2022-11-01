using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{

    [SerializeField] private GameObject[] CameraPos;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if(CameraPos[0].activeSelf){

            YouPosisMyPos(CameraPos[0])
            if(CameraPos[1].activeSelf){
                Debug.Log("I like the car more");
            }
        }

    else if(CameraPos[1].activeSelf){
            YouPosisMyPos(CameraPos[1])
    }
    else{
        Debug.Log("No active position for camera. REEEEEE!!!");
    }

    }

    void YouPosisMyPos(GameObject reference){

    }
}
