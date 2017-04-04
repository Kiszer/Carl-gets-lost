using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingBullet : Bullet {

    private GameObject targetEnemy;

	void Update () {
        if(targetEnemy)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetEnemy.transform.position, flightSpeed/100);
        }
        else
        {
            FindEnemy();
        }
	}

    public override void Shoot(float x, float y)
    {
        //
    }

    private void FindEnemy()
    {
        NPCController[] allEnemies = FindObjectsOfType<NPCController>();
        float closestDistance = Mathf.Infinity;
        GameObject closestEnemy = null;
        for (int i = 0; i < allEnemies.Length; i++)
        {
            if (Vector2.Distance(allEnemies[i].transform.position, transform.position) < closestDistance)
            {
                closestEnemy = allEnemies[i].gameObject;
                closestDistance = Vector2.Distance(allEnemies[i].transform.position, transform.position);
            }
        }
        targetEnemy = closestEnemy;
    }
}
