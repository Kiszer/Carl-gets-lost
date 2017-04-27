using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingBullet : Bullet {

    private GameObject targetEnemy;
    private float turnDelta = .02f;

	protected override void Update()
    {
        base.Update();
        if(targetEnemy)
        {
            //Old method.  Doesn't work as expected
            //transform.position = Vector2.MoveTowards(transform.position, targetEnemy.transform.position, flightSpeed/100);
            /*Quaternion curRotation = transform.rotation;
            transform.LookAt(targetEnemy.transform);
            GetComponent<Rigidbody2D>().velocity += (Vector2)transform.forward * (1/flightSpeed);
            transform.rotation = curRotation;*/
            /*Quaternion curRotation = transform.rotation;
            transform.LookAt(targetEnemy.transform.position);
            Vector3 velocity = GetComponent<Rigidbody2D>().velocity.normalized * GetComponent<Rigidbody2D>().velocity.magnitude * 0.99f;
            Vector3 look = transform.forward.normalized * GetComponent<Rigidbody2D>().velocity.magnitude * 0.01f;
            GetComponent<Rigidbody2D>().velocity = velocity + look;
            transform.rotation = curRotation;*/
            Quaternion curRotation = transform.rotation;
            Vector3 diff = targetEnemy.transform.position - transform.position;
            diff.Normalize();
            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

            Vector3 velocity = GetComponent<Rigidbody2D>().velocity.normalized * flightSpeed * (1 - turnDelta * upgradeLevel);
            Vector3 look = transform.up.normalized * flightSpeed * turnDelta * upgradeLevel;
            GetComponent<Rigidbody2D>().velocity = velocity + look;

            //transform.rotation = curRotation;
        }
        else
        {
            FindEnemy();
        }
	}

    public override void Shoot(float x, float y)
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(x*flightSpeed, y*flightSpeed);
    }

    public override void IncreaseUpgradeLevel(int upgradeAmount)
    {
        base.IncreaseUpgradeLevel(upgradeAmount);
        turnDelta = turnDelta * upgradeAmount;
        //latency = latency - latency / 5 * upgradeAmount;
        latency = 0.1f;
        if(latency < 0.05f)
        {
            latency = 0.05f;
        }
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
