using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyhealth : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.CompareTag("punching"))
        {
            Destroy(gameObject);
        }
    }
}
