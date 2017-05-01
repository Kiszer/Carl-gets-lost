using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultySetter : MonoBehaviour {

    public int difficulty = 1;

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
                FindObjectOfType<SpawnManager>().difficulty = difficulty;
                Destroy(gameObject);
            }
        }
    }

    public void SetDifficulty(int value)
    {
        difficulty = value;
    }
}
