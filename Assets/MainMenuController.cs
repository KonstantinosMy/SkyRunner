using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuController : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject SettingMenu; 


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

    public void QuitGame()
    {
        Application.Quit();
    }
}
