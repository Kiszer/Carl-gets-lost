﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.ImageEffects;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public Image healthBar;

    public GameObject bulletFab;
    private Bullet bulletFabScript;
    public Transform bulletSpawnPnt;

    public int bulletUpgradeLevel = 1;

    private bool shooting = true;

    private int maxHealth = 5;
    private int curHealth = 5;

    public int GetHealth() { return curHealth; }

    private float rotationX = 0;
    private float rotationY = 1;

    private float movementScalar = 0.1f;
    public bool paused;
    public bool alive = true;

    public Color shootColor = Color.red;

    private Vector3 baseScale = new Vector3(0.2f, 0.2f, 0.2f);

    void Start()
    {
        bulletFabScript = bulletFab.GetComponent<Bullet>();
        StartCoroutine(ConstantShoot());
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
        }
        if (paused)
        {
            Time.timeScale = 0;
            movementScalar = 0f;
        }
        else if (!paused)
        {
            Time.timeScale = 1;
            movementScalar = 0.1f;
        }
    }
    private IEnumerator ConstantShoot()
    {
        while(shooting)
        {
            Shoot(rotationX, rotationY);
            print(bulletFabScript.GetLatency());
            yield return new WaitForSeconds(bulletFabScript.GetLatency());
        }
    }

    /* Is called when something touches the player */
    public void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "NPC")
        {
            TakeDamage(1);
            Destroy(col.gameObject);
        }
    }

    public void IncreaseMaxHealth(int amount)
    {
        maxHealth += amount;
    }

    public void Heal(int amount)
    {
        curHealth += amount;
        if(curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }
        UpdateHealthBar();
    }

    public void TakeDamage(int damage)
    {
        curHealth -= damage;
        if(curHealth <= 0)
        {
            Die();
        }
        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
        healthBar.fillAmount = (float)curHealth / (float)maxHealth;
    }

    void GameOver()
    {
        SceneManager.LoadScene(2);
    }

    public void Die()
    {
        alive = false;
        Time.timeScale = 0;
        movementScalar = 0f;
        GameOver();
    }

    public void Shoot(float x, float y)
    {
        GameObject newBullet = Instantiate(bulletFab);
        newBullet.GetComponent<Bullet>().IncreaseUpgradeLevel(bulletUpgradeLevel);
        newBullet.transform.position = bulletSpawnPnt.position;
        newBullet.GetComponent<Bullet>().Shoot(x, y);
        newBullet.GetComponent<Bullet>().SetColor(shootColor);
    }

    public void Rotate(float x, float y)
    {
        rotationX = x;
        rotationY = y;
        if(x < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 90);
        }
        if (x > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, -90);
        }
        if (y < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 180);
        }
        if (y > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void ResizePlayer()
    {
        transform.localScale = baseScale;
    }

    public void MovePlayer(float x, float y)
    {
        bool resetX = false;
        bool resetY = false;
        Vector3 origPos = transform.position;
        transform.position += new Vector3(x*movementScalar, y*movementScalar, 0);
        Vector3 newPos = transform.position;
        Vector3 cameraPos = Camera.main.WorldToViewportPoint(transform.position);
        if (cameraPos.x < 0.0f || cameraPos.x > 1.0f)
        {
            resetX = true;
        }
        if (cameraPos.y < 0.0f || cameraPos.y > 1.0f)
        {
            resetY = true;
        }
        transform.position = new Vector2(resetX ? origPos.x : newPos.x, resetY ? origPos.y : newPos.y);
    }
}
