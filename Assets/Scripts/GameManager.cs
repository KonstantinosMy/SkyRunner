using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
public class GameManager : MonoBehaviour {

    int score;
    public TextMeshProUGUI HighestScore;

    public static GameManager inst;

    // [SerializeField] Text scoreText;
    public TextMeshProUGUI scoreTxt;
    [SerializeField] PlayerMovement playerMovement;
  
    public void IncrementScore ()
    {
        score++;
        scoreTxt.text = "Score: " + score;

        if(score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            HighestScore.text = "HIGHSCORE: " + score.ToString();
        }


        // Increase the player's speed
        //playerMovement.speed += playerMovement.speedIncreasePerPoint;
    }

    public void ResetScore()
    {
        PlayerPrefs.DeleteAll();
    }

    private void Awake ()
    {
        inst = this;
    }

    private void Start () {
        HighestScore.text = "HIGHSCORE: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
	}

	private void Update () {
	
	}
}