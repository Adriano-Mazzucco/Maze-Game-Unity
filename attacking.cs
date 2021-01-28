using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attacking : MonoBehaviour
{
    public bool atking = false;
    public Animator animator;
    private bool doubleAtk, tripleAtk = false;
    public bool extraDmg = false;
    private float speed = 0.5f;
    private RoomTemplates templates;
    

    void Start()
    {
        animator.SetBool("IsAttacking", false);
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
    }

    /*----
     * runs attack animation
     * starts attack timer
     * checks for buffs
     * instantiates bullets 
     */
    void Update()
    {
        if (Input.GetMouseButton(1) && atking == false)
        {
            atking = true;
            animator.SetBool("IsAttacking", true);
            StartCoroutine(setAttack(speed));
            Vector3 rotation = transform.rotation.eulerAngles;
            Instantiate(templates.bullet, transform.position, transform.rotation);
            if (doubleAtk == true)
                Instantiate(templates.bullet, transform.position, Quaternion.Euler(new Vector3(rotation.x, rotation.y+180, rotation.z)));
            if (tripleAtk == true)
            {
                Instantiate(templates.bullet, transform.position, Quaternion.Euler(new Vector3(rotation.x, rotation.y + 20, rotation.z)));
                Instantiate(templates.bullet, transform.position, Quaternion.Euler(new Vector3(rotation.x, rotation.y - 20, rotation.z)));
            }
        }
    }

    /*--
     * delays attack 
     */
    IEnumerator setAttack(float time)
    {
        yield return new WaitForSeconds(time);
        atking = false;
        animator.SetBool("IsAttacking", false);

    }

    /*----
     * on collisison checks if its a buff
     * if it is applys the buff
     */
    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.CompareTag("doubleshot"))
            doubleAtk = true;
        if (hit.gameObject.CompareTag("tripleAtk"))
            tripleAtk = true;
        if (hit.gameObject.CompareTag("atkspeed"))
            speed = 0.2f;
        if (hit.gameObject.CompareTag("extraDmg"))
            extraDmg = true;
    }
}
