using System.Collections;
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
    public bool paused = false;
    public bool alive = true;


    public Color shootColor = Color.red;

    private Vector3 baseScale = new Vector3(0.2f, 0.2f, 0.2f);


    public static int score = 0;
    public Text scoreText;
    public Text upgradeText;
    public string diff;

    void Start()
    {
        score = 0;
        if(scoreText == null)
        {
            scoreText = GameObject.Find("Score Text").GetComponent<Text>();
        }
        bulletFabScript = bulletFab.GetComponent<Bullet>();
        StartCoroutine(ConstantShoot());
        
    }
    void FixedUpdate()
    {
        scoreText.text = "Score: " + score.ToString();
        upgradeText.text = bulletUpgradeLevel.ToString();
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
            yield return new WaitForSeconds(bulletFabScript.GetLatency(bulletUpgradeLevel));
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
        updateHighScore();
        SceneManager.LoadScene(2);
    }

    public void Die()
    {
        alive = false;
        Time.timeScale = 0;
        movementScalar = 0f;
        if(FindObjectsOfType<PlayerController>().Length > 1)
        {
            FindObjectOfType<InputManager>().RemovePlayer(this);
            Destroy(gameObject);
        }
        else
        {
            GameOver();
        }
    }

    public void Shoot(float x, float y)
    {
        GameObject newBullet = Instantiate(bulletFab);
        newBullet.GetComponent<Bullet>().IncreaseUpgradeLevel(bulletUpgradeLevel);
        newBullet.transform.position = bulletSpawnPnt.position;
        newBullet.GetComponent<Bullet>().SetColor(shootColor);
        newBullet.GetComponent<Bullet>().Shoot(x, y);
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

    public void updateHighScore()
    {
        int tempScore = score;
        int temp;
        if (SpawnManager.difficulty == 1)
        {
            diff = "easy";
        }
        if (SpawnManager.difficulty == 2)
        {
            diff = "medium";
        }
        if (SpawnManager.difficulty == 4)
        {
            diff = "hard";
        }
        for(int i=1; i<6;i++)
        {
            if(tempScore > PlayerPrefs.GetInt(("highscore" + diff + i.ToString())))
            {
                temp = PlayerPrefs.GetInt("highscore" + diff + i.ToString());
                PlayerPrefs.SetInt("highscore" + diff + i.ToString(), tempScore);
                tempScore = temp;
            }
        }



        /*  if(score > PlayerPrefs.GetInt("highscore1"))
          {
              temp = PlayerPrefs.GetInt("highscore1");
              tempScore = PlayerPrefs.GetInt("highscore2");
              PlayerPrefs.SetInt("highscore1", score);
              PlayerPrefs.SetInt("highscore2", temp);
              PlayerPrefs.SetInt("highscore3", tempScore);

          }
          if(score > PlayerPrefs.GetInt("highscore2") && score < PlayerPrefs.GetInt("highscore1"))
          {
              tempScore = PlayerPrefs.GetInt("highscore2");
              PlayerPrefs.SetInt("highscore2", score);
              PlayerPrefs.SetInt("highscore3", tempScore);
          }
          if(score > PlayerPrefs.GetInt("highscore3") && score < PlayerPrefs.GetInt("highscore2"))
          {
              PlayerPrefs.SetInt("highscore3", score);
          }*/



    }
}
