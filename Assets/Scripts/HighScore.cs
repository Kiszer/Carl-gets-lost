using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    private const int length = 5;
    public Text highScore;
    public Text highScore1;
    public Text highScore2;
    public Text highScore3;


    // Use this for initialization
    void Start()
    {

        highScore1.text = PlayerPrefs.GetInt("highscore1").ToString();
        highScore2.text = PlayerPrefs.GetInt("highscore2").ToString();
        highScore3.text = PlayerPrefs.GetInt("highscore3").ToString();

    }
    
    
    

	
}
