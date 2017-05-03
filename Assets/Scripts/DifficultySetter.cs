using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultySetter : MonoBehaviour {

    public int difficulty = 1;
    public int playerNum = 1;

	void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if(SceneManager.GetActiveScene().name != "Main Menu")
        {
            if (FindObjectOfType<SpawnManager>())
            {
                SpawnManager.difficulty = difficulty;
                if(FindObjectOfType<InputManager>() && playerNum > 1)
                {
                    FindObjectOfType<InputManager>().SetNewPlayers(playerNum);
                }
                Destroy(gameObject);
            }
        }
    }

    public void SetDifficulty(int value)
    {
        difficulty = value;
    }

    public void SetPlayerNum(int value)
    {
        playerNum = value;
    }
}
