using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour {

    public GameObject[] powerUpArr;

    private Vector2 destination;
    private float powerUpDropChance = .1f;
    private float moveSpeed = 0.04f;
    private GameObject player;
    private static readonly int MAX_HEALTH = 70;
    private int currHealth = MAX_HEALTH;

    void Start()
    {
        player = FindObjectOfType<PlayerController>().gameObject;
        destination = new Vector2(12 * (Random.Range(0f, 1f) > 0.5f ? -1 : 1), Random.Range(-6f, 6f));
        transform.position = new Vector2(-destination.x, Random.Range(-6, 6f));
    }

    void Update()
    {
        destination = player.transform.position;
        transform.position = Vector2.MoveTowards(transform.position, destination, moveSpeed);
        if ((Vector2)transform.position == destination)
        {
            Death();
        }

    }

    void GetHit(int damage)
    {
        currHealth -= damage;
        if(currHealth <= 0)
        {
            Death();
        }
        moveSpeed += .001f;
    }

    void Death()
    {
        Destroy(gameObject);
        if(Random.Range(0f,1f) < powerUpDropChance)
        {
            int chosenPowerup = Random.Range(0, powerUpArr.Length);
            //TODO: spawn powerup
        }
    }
}
