using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textupdate : MonoBehaviour
{
    private int level, Health;
    public Text txt;
    

    void Start()
    {
        txt = GameObject.Find("Canvas/LevelText").GetComponent<Text>();
    }

    //updates the on screen text to display health and level
    void Update()
    {
        level = GameObject.Find("Exit").GetComponent<exit>().level;
        Health = GameObject.Find("Robot").GetComponent<move>().health;
        txt.text = "Level : " + level.ToString() + " Health : " + Health;
    }
}
