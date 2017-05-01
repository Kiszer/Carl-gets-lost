using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    public GameObject bulletFab;
    public int healthRestoration = 0;
    public int healthUpgrade = 0;
    protected float waitTimer = 6;
    protected float flashTimer = 5;

    void Start()
    {
        StartCoroutine(DestructTimer());
    }

    void FixedUpdate()
    {
        //Spin
        transform.Rotate(0, 0, 1f);
    }

    IEnumerator DestructTimer()
    {
        yield return new WaitForSeconds(flashTimer);
        float timer = waitTimer - flashTimer;
        while(timer > 0)
        {
            timer -= 0.1f;
            GetComponent<SpriteRenderer>().enabled = !GetComponent<SpriteRenderer>().enabled;
            yield return new WaitForSeconds(0.1f);
        }
        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            PlayerController playerController = col.gameObject.GetComponent<PlayerController>();
            if(bulletFab)
            {
                Bullet playerBullet = playerController.bulletFab.GetComponent<Bullet>();
                if (playerBullet.GetType() == bulletFab.GetComponent<Bullet>().GetType())
                {
                    playerController.bulletUpgradeLevel++;
                }
                else
                {
                    playerController.bulletUpgradeLevel = 1;
                    playerController.bulletFab = bulletFab;
                }
            }
            if(healthRestoration != 0)
            {
                playerController.Heal(healthRestoration);
            }
            if(healthUpgrade != 0)
            {
                playerController.IncreaseMaxHealth(healthUpgrade);
            }
            Destroy(gameObject);
        }
    }
}
