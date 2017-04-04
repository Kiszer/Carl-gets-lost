using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    protected float flightSpeed = 5;

	protected void Update()
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
        GetComponent<Rigidbody2D>().velocity = new Vector2(x * flightSpeed, y * flightSpeed);
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
