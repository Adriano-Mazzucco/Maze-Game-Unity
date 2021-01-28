using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowturn : MonoBehaviour
{

    new Vector3 location;
    
    void Start()
    {
        
    }

    /*----
     * sets arrow location
     * rotates arrow towars the end point
     * functions as a compase for the player
     */
    void Update()
    {
        Vector3 temp = GameObject.FindGameObjectWithTag("Robot").transform.position;
        temp.x += 17;
        temp.y += 30;
        temp.z += 26;
        transform.position = temp;

        location = GameObject.FindGameObjectWithTag("end").transform.position;
        transform.LookAt(new Vector3(location.x, 0, location.z));
    }
}
