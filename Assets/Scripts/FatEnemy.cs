using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatEnemy : NPCController {

    
    void Start()
    {
        base.Start();
        moveSpeed = 0.02f;
        maxHealth = 100;
        curHealth = maxHealth;
        curColor = Color.blue;
    }
}
