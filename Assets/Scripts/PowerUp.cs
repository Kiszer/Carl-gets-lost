using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    public GameObject bulletFab;
    public int healthRestoration = 0;
    public int healthUpgrade = 0;

    void Update()
    {
        //Spin
        transform.Rotate(0, 0, 1f);
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
