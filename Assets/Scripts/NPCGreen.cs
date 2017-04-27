using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCGreen : NPCController
{

    // Use this for initialization
    void Start()
    {
        base.Start();
    }

    void GetHit(int damage, Color color)
    {
        if (color != Color.green)
        {
            damage = damage / 2;
        }
        curHealth -= damage;
    }
}
