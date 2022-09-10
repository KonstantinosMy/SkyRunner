using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {

    int score;
    public TextMeshProUGUI HighestScore;

    public static GameManager inst;

    // [SerializeField] Text scoreText;
    public TextMeshProUGUI scoreTxt;
    public PlayerMovement playerMovement;

    private int counter;
  
    public void IncrementScore ()
    {
        score++;
        scoreTxt.text = "Score: " + score;

        if(score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            HighestScore.text = "HIGHSCORE: " + score.ToString() + " coins";
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
        HighestScore.text = "HIGHSCORE: " + PlayerPrefs.GetInt("HighScore", 0).ToString() + " coins";
        counter = 2;
	}

	private void Update () {
	
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
        if (Input.GetKeyDown(KeyCode.Escape) && counter%2==0)
        {
            playerMovement.PauseMenu();
            counter++;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && counter % 2 != 0)
        {
            playerMovement.ResumeMenu();
            counter++;
        }

    }
}