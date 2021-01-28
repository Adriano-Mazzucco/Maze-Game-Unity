using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour

    
{
    public bool wall = false;
    public Rigidbody body;
    Vector3 targetPosition;
    public bool moving = false;
    public int health;
    public static int enemies; 
    public Animator animator;
    
    void Start()
    {
        body = GetComponent<Rigidbody>();
        health = 100;
        enemies = 0;
    }

    /*----
     * on mouse click runs SetTargetPosisiton function
     * Changes animation depending on character movement runs movement function
     */
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            SetTargetPosition();
            
        }

        if (moving == true)
        {
            Movement();
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }

    /*----
     * uses raycast to determine mouse position
     * rotates character towards clicked location
     */
    void SetTargetPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 1000))
        {
            targetPosition = hit.point;
            this.transform.LookAt(new Vector3(targetPosition.x, 0, targetPosition.z));

        }
        moving = true;
    }

    /*----
     * moves player towards mouse position
     * 
     */
    void Movement()
    {
        transform.position = Vector3.MoveTowards(transform.position, (new Vector3(targetPosition.x, 0, targetPosition.z)), 50 * Time.deltaTime);

        if (transform.position == new Vector3(targetPosition.x, 0, targetPosition.z))
            moving = false;
    }

    /*----
     * used for collision with enemies
     * reduces health based on which enemy hits him
     * if health is 0 level restarts
     */
    void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.CompareTag("evilrobot"))
        {
            health--;
            //Debug.Log(health);
        }else if (hit.gameObject.CompareTag("bigevil"))
        {
            health = health - 2;
        } 

        if (health == 0)
            Application.LoadLevel("Mazenew");
    }

    /*----
     * increases health if collides with a health pod
     */
    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.CompareTag("health"))
        {
            health = health + 10;
            if (health > 100)
                health = 100;
        }
    }

}
