using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Unity.VisualScripting.Member;

public class GameManager : MonoBehaviour
{
    //public AudioClip Source;
    //public GameObject deathCamera;
    public GameObject player;
    public GameObject mainMenu;

    private void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        Time.timeScale = 0;
    }




    public void Restart()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void ClickStart()
    {
        mainMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    /*public void PauseGame()
    {
        Time.timeScale = 0;   
    }                           */

}
