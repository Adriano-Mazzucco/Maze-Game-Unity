using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramove : MonoBehaviour
{
    void Start()
    {
        
    }

    //moves the camera 
    void Update()
    {
        Vector3 temp = GameObject.FindGameObjectWithTag("Robot").transform.position;
        temp.x += 40;
        temp.y += 60;
        temp.z += 10;
        transform.position = temp;
    }
}
