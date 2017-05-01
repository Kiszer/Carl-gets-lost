using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour {

    public GameObject[] powerUpArr;
    protected Vector2 destination;
    protected float powerUpDropChance = .1f;
    protected float moveSpeed = 0.04f;
    protected GameObject player;
    protected static int maxHealth = 50;
    protected int curHealth = maxHealth;
    public bool paused;
    public Color curColor;
    private Color[] possibleColors = { Color.green, Color.red, Color.yellow, Color.blue };

    private SpawnManager spawnManager;

    public GameObject currentPlayer;

    protected void Start()
    {
        try
        {
            player = FindObjectOfType<PlayerController>().gameObject;
        }catch { }
        spawnManager = FindObjectOfType<SpawnManager>();

        destination = new Vector2(12 * (Random.Range(0f, 1f) > 0.5f ? -1 : 1), Random.Range(-6f, 6f));
        transform.position = new Vector2(-destination.x, Random.Range(-6, 6f));
        paused = false;
        curColor = possibleColors[Random.Range(0, spawnManager.difficulty)];
        if(GetComponent<SpriteRenderer>())
        {
            GetComponent<SpriteRenderer>().color = curColor;
        }
    }

    void Update()
    {
        transform.Rotate(0, 0, 1);
        //destination = player.transform.position;
        transform.position = Vector2.MoveTowards(transform.position, destination, moveSpeed);
        if ((Vector2)transform.position == destination)
        {
            Death();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
        }
        if (paused)
        {
            Time.timeScale = 0;
            moveSpeed = 0f;
        }
        else if (!paused)
        {
            Time.timeScale = 1;
            moveSpeed = 0.04f;
        }
    }

    public void GetHit(int damage)
    {
        curHealth -= damage;
        if(curHealth <= 0)
        {
            Death();
        }
        moveSpeed += .001f;
    }

    public void GetHit(int damage, Color color)
    {
        if (color != curColor)
        {
            damage = damage / 2;
        }
        curHealth -= damage;
        if(curHealth <= 0)
        {
            Death();
        }
        moveSpeed += .001f;
    }

    public void Death()
    {
        if(Random.Range(0f,1f) < powerUpDropChance)
        {
            int chosenPowerup = Random.Range(0, powerUpArr.Length);
            GameObject newPowerUp = Instantiate(powerUpArr[chosenPowerup]);
            newPowerUp.transform.position = transform.position;
        }
        Destroy(gameObject);
    }
}


