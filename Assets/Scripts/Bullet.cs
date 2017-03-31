using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    protected float flightSpeed = 5;

    //Bullet Speed
    public void Shoot(float x, float y)
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(x * flightSpeed, y * flightSpeed);
    }

    //Standard Bullet
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<NPCController>())
        {
            //call function from NPC
        }
    }

}
