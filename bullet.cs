using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    Vector3 targetPosition;
    
    //Determines if bullet damage is buffed
    //sets color of bullet
    void Start()
    {
        bool dmg = ((GameObject.Find("attack")).GetComponent<attacking>()).extraDmg;
        if(dmg)
            GetComponent<Renderer>().material.color = new Color(0.5f, 1, 1);

    }

    /*----
     * moves forwards
     * if too far from player destroys
     */
    void Update()
    {
        transform.Translate(Vector3.forward  * Time.deltaTime * 75);
        float distance = Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Robot").transform.position);
        if (distance > 150)
            Destroy(gameObject);
    }

    /*----
     * if it collides with something thats not the player destroys self
     */
    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.CompareTag("punching") || hit.gameObject.CompareTag("Robot"))
        {

        }
        else
            Destroy(gameObject);
            
    }
}
