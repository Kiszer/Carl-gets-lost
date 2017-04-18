using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{


    public bool paused;


    // Use this for initialization
    void Start()
    {
        paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
        }
        if (paused)
        {
            Time.timeScale = 0;
        }
        else if (!paused)
        {
            Time.timeScale = 1;
        }
    }
    public bool playerDead()
    {
        if (!GameObject.Find("Player").GetComponent<PlayerController>().alive)
        {
            return true;
        }
        else
            return false;


    }

}
