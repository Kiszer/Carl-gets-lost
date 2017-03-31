using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingBullet : Bullet {

    private GameObject targetEnemy;

	// Use this for initialization
	void Start () {
        //targetEnemy = FindObjectsOfType<NPCController>()
        NPCController[] allEnemies = FindObjectsOfType<NPCController>();
        float closestDistance = Mathf.Infinity;
        GameObject closestEnemy = null;
        for(int i = 0; i < allEnemies.Length; i++)
        {
            if(Vector2.Distance(allEnemies[i].transform.position, transform.position) < closestDistance)
            {
                closestEnemy = allEnemies[i].gameObject;
                closestDistance = Vector2.Distance(allEnemies[i].transform.position, transform.position);
            }
        }
        targetEnemy = closestEnemy;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector2.MoveTowards(transform.position, targetEnemy.transform.position, flightSpeed);
	}
}
