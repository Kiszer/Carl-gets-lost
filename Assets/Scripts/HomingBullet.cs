using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingBullet : Bullet {

    private GameObject targetEnemy;

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
            Quaternion curRotation = transform.rotation;
            transform.LookAt(targetEnemy.transform.position);
            Vector3 velocity = GetComponent<Rigidbody2D>().velocity.normalized * GetComponent<Rigidbody2D>().velocity.magnitude * 0.99f;
            Vector3 look = transform.forward.normalized * GetComponent<Rigidbody2D>().velocity.magnitude * 0.01f;
            GetComponent<Rigidbody2D>().velocity = velocity + look;
            transform.rotation = curRotation;
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
