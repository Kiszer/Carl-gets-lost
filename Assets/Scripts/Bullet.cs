using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    protected float flightSpeed = 5;
    protected float spread = .2f;
    protected float latency = .2f;
    public float GetLatency() { return latency; }
    protected int upgradeLevel = 0;
    protected int damage = 50;

    virtual protected void Update()
	{
		Vector3 cameraPos = Camera.main.WorldToViewportPoint(transform.position);
        if (cameraPos.x < 0.0f || cameraPos.x > 1.0f)
        {
            Destroy(gameObject);
        }
        if (cameraPos.y < 0.0f || cameraPos.y > 1.0f)
        {
            Destroy(gameObject);
        }
	}
	
    virtual public void Shoot(float x, float y)
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2((x + Random.Range(-1, 1) * spread) * flightSpeed, (y + Random.Range(-1, 1) * spread) * flightSpeed);
        if(upgradeLevel > 1)
        {
            for(int i = 1; i < upgradeLevel; i++)
            {
                GameObject newBullet = Instantiate(gameObject);
                newBullet.transform.position = transform.position;
                newBullet.GetComponent<Bullet>().Shoot(x, y, false);
            }
        }
    }

    public void Shoot(float x, float y, bool originalBullet)
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2((x + Random.Range(-1, 1) * spread) * flightSpeed, (y + Random.Range(-1, 1) * spread) * flightSpeed);
    }

    virtual public void IncreaseUpgradeLevel(int upgradeAmount)
    {
        upgradeLevel += upgradeAmount;
    }

    //Standard Bullet
    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<NPCController>())
        {
            collision.gameObject.GetComponent<NPCController>().GetHit(damage);
            Destroy(gameObject);
        }
    }
}
