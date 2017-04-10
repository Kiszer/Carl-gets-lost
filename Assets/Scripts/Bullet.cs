using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float flightSpeed = 5;
    public float spread;
    public float latency;
    private int upgradeLevel = 0;

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
	
    //Bullet Speed
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
            collision.gameObject.GetComponent<NPCController>().Death();
            Destroy(gameObject);
        }
    }
}
