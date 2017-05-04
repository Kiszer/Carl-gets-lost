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
    public Text highScore4;
    public Text highScore5;
    public Text yourScore;
    public string difficultyString;


    // Use this for initialization
    void Start()
    {
        try
        {
            if(SpawnManager.difficulty == 1)
            {
                highScore.text = "Easy High Scores";
                difficultyString = "easy";
            }
            if (SpawnManager.difficulty == 2)
            {
                highScore.text = "Medium High Scores";
                difficultyString = "medium";
            }
            if (SpawnManager.difficulty == 4)
            {
                highScore.text = "Hard High Scores";
                difficultyString = "hard";
            }
            highScore1.text = PlayerPrefs.GetInt("highscore"+ difficultyString +"1").ToString();
            highScore2.text = PlayerPrefs.GetInt("highscore" + difficultyString + "2").ToString();
            highScore3.text = PlayerPrefs.GetInt("highscore" + difficultyString + "3").ToString();
            highScore4.text = PlayerPrefs.GetInt("highscore" + difficultyString + "4").ToString();
            highScore5.text = PlayerPrefs.GetInt("highscore" + difficultyString + "5").ToString();
            yourScore.text = "Your Score: " + PlayerController.score.ToString();
        }
        catch { }
    }
    
    
    

	
}
