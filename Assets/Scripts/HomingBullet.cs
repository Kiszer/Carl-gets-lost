using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingBullet : Bullet {

    private GameObject targetEnemy;
    private float turnDeltaUpgrade = .002f;
    private float turnDelta = .01f;
    
    protected void Start()
    {
        latency = 0.2f;
    }

	protected override void FixedUpdate()
    {
        base.FixedUpdate();
        if(1.0f/Time.deltaTime < 30)
        {
            return;
        }
        FindEnemy();
        if(targetEnemy)
        {
            Quaternion curRotation = transform.rotation;
            Vector3 diff = targetEnemy.transform.position - transform.position;
            diff.Normalize();
            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

            Vector3 velocity = GetComponent<Rigidbody2D>().velocity.normalized * flightSpeed * (1 - turnDelta * upgradeLevel);
            Vector3 look = transform.up.normalized * flightSpeed * turnDelta * upgradeLevel;
            GetComponent<Rigidbody2D>().velocity = velocity + look;
        }
	}

    public override void Shoot(float x, float y)
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(x*flightSpeed, y*flightSpeed);
    }

    public override float GetLatency(int upgradeAmount)
    {
        return latency * Mathf.Pow(0.9f, upgradeAmount);
    }

    public override void IncreaseUpgradeLevel(int upgradeAmount)
    {
        base.IncreaseUpgradeLevel(upgradeAmount);
        turnDeltaUpgrade = turnDeltaUpgrade * upgradeLevel;
        //latency = 0.1f;
        /*if(latency < 0.05f)
        {
            latency = 0.05f;
        }*/
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
