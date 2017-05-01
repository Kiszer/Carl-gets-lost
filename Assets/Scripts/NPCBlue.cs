using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBlue : NPCController
{
    //private Color curColor;
    //private Color[] possibleColors = { Color.red, Color.blue, Color.yellow, Color.green };

    // Use this for initialization
    void Start()
    {
        base.Start();
        //curColor = possibleColors[Random.Range(0, possibleColors.Length)];
        GetComponent<SpriteRenderer>().color = curColor;
    }

    void GetHit(int damage, Color color)
    {
        if (color != curColor)
        {
            damage = damage / 2;
        }
        curHealth -= damage;
    }
}
