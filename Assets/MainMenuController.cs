using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class MainMenuController : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject SettingMenu;

    public TextMeshProUGUI highscore;
    public TextMeshProUGUI besttime;
    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void SettingsMenu()
    {
        MainMenu.SetActive(false);
        SettingMenu.SetActive(true);
    }

    public void ReturnToMenu()
    {
        MainMenu.SetActive(true);
        SettingMenu.SetActive(false);
    }

    private void Start()
    {
        Time.timeScale = 1;
        highscore.text = "HIGHSCORE: " + PlayerPrefs.GetInt("HighScore", 0).ToString() + " coins";
        besttime.text = "BEST TIME: " + PlayerPrefs.GetInt("BestTime", 0).ToString() + " seconds";
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
