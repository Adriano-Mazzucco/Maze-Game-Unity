using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class exit : MonoBehaviour
{

    private RoomTemplates templates;
    public int level;
    Vector3 position;
    
    /*----
     * sets level to 1
     * sets end target, cnavas and the text changer to not be destroyed on load
     */
    void Awake()
    {
        level = 1;
        DontDestroyOnLoad(GameObject.FindGameObjectWithTag("end"));
        DontDestroyOnLoad(GameObject.Find("Canvas"));
        DontDestroyOnLoad(GameObject.Find("textchanger"));
    }
    void Start() { }

    void  Update()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("setposition", 3f);     
    }

    
    // sets the end goal location to the last position
    void setposition()
    {
        position = (templates.rooms[templates.rooms.Count - 1]).transform.position;
        transform.position = new Vector3(position.x, 10f, position.z);
    }

    //if robot collides with end target starts new level 
    void OnTriggerEnter(Collider player)
    {
        if (player.CompareTag("Robot"))
        {
            level++;
            Application.LoadLevel("Mazenew");
        }
    }
}
