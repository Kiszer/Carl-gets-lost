using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class PlayerController : MonoBehaviour {

    public GameObject bulletFab;

    private float movementScalar = 0.1f;

    private Vector3 baseScale = new Vector3(0.2f, 0.2f, 0.2f);

    /* Is called when something touches the player */
    /*public void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "NPC")
        {
            Color npcColor = col.gameObject.GetComponent<ParticleSystem>().main.startColor.color;
            Destroy(col.gameObject);
            successLevel += colorSimilarity(curColor, npcColor) - 0.5f;
            ResizePlayer();
        }
    }*/

    public void Shoot(float x, float y)
    {
        Rotate(x, y);

        GameObject newBullet = Instantiate(bulletFab);
        newBullet.transform.position = transform.position;
        newBullet.GetComponent<Bullet>().Shoot(x, y);
    }

    public void Rotate(float x, float y)
    {
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
