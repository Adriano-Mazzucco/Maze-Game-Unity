using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawn : MonoBehaviour
{
    public int openingDirection;
    private RoomTemplates templates;
    public GameObject intersection;
    private int rand, rand2;
    public bool spawned = false;

    /*----
     * spawns a new room
     * has a chance to spawn a random buff for the player
     */
    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        if (openingDirection == 0)
            spawned = true;
        Invoke("Spawn", 0.1f);
        rand2 = Random.Range(0, 5);
        if (rand2 == 1){
            rand = Random.Range(0, templates.Powers.Length);
            Instantiate(templates.Powers[rand], new Vector3(transform.position.x, 9, transform.position.z), templates.Powers[rand].transform.rotation);
        }

    }
    
    /*----
     * determines which direction opening is facing
     * spawns a random appropirate room based on the opening 
     * repeatdly spawns enemys on the location
     */
    void Spawn()
    {

        if(spawned == false){
            if (openingDirection == 1)
            {
                rand = Random.Range(0, templates.bottomRooms.Length);
                Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
                InvokeRepeating("enemyspawn", 1f, 2.5f);
            }
            else if (openingDirection == 2)
            {
                rand = Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
                InvokeRepeating("enemyspawn", 1f, 2.5f);
            }
            else if (openingDirection == 3)
            {
                rand = Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
                InvokeRepeating("enemyspawn", 1f, 2.5f);
            }
            else if (openingDirection == 4)
            {
                rand = Random.Range(0, templates.rightRooms.Length);
                Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
                InvokeRepeating("enemyspawn", 1f, 2.5f);
            }
        }
        spawned = true;
    }

    /*
     * checks the current number of enemies
     * if less than 100 spawns a random enemy
     * increments the count of enemies
     */
    void enemyspawn()
    {
        int enemies = move.enemies;
        if(enemies < 100)
        {
            rand = Random.Range(0, templates.enemies.Length);
            Instantiate(templates.enemies[rand], transform.position, templates.enemies[rand].transform.rotation);
            move.enemies++;
        }
    }

    /*
     * if collides with another spawner checks if both have not spawned rooms
     * if neither has spawns an intersection
     */
    void OnTriggerEnter(Collider other){
        if (other.CompareTag("Spawnpoint")) {
            if (other.GetComponent<RoomSpawn>().spawned == false && spawned == false)
            {
                Instantiate(intersection, transform.position, intersection.transform.rotation);
                Destroy(gameObject);
            }
            spawned = true;
        }
    }
}
