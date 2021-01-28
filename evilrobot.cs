using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class evilrobot : MonoBehaviour
{
    new Vector3 location;
    public Animator animator;
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    /*----
     * looks towards player
     * sets animation to walking or attack if close to player
     * moves towards the players
     * if too far from the player destroys the enemy
     */
    void Update()
    {
        location = GameObject.FindGameObjectWithTag("Robot").transform.position;
        transform.LookAt(new Vector3(location.x, 0, location.z));
        if (transform.position.x - location.x < 2 && transform.position.z -location.z < 2)
        {
            animator.SetBool("evilAttack", true);

        }else
            animator.SetBool("evilAttack", false);

        transform.position = Vector3.MoveTowards(transform.position, (new Vector3(location.x, 0, location.z)), 40 * Time.deltaTime);

        float distance = Vector3.Distance(transform.position, location);
        if (distance > 500)
        {
            move.enemies--;
            Destroy(gameObject);
        }


    }
    /*----
     * if collides with a bullet reduces health
     * if health is a 0 destroy the enemy
     */
    void OnTriggerEnter(Collider hit)
    {
        bool dmg = ((GameObject.Find("attack")).GetComponent<attacking>()).extraDmg;
        if (hit.CompareTag("bullet"))
        {
            health--;
            if (dmg)
                health--;
        }
        if (health < 1)
        {
            move.enemies--;
            Destroy(gameObject);
        }
    }
}
