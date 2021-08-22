using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlayController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("/UI/CnvPaused").GetComponent<Canvas>().enabled = false;
        Time.timeScale = 1;
        GameObject.Find("/UI/CnvGamePlay/BtnPause").GetComponent<Button>().onClick.AddListener(pauseGame);
        GameObject.Find("/UI/CnvPaused/BtnPlay").GetComponent<Button>().onClick.AddListener(playGame);
        GameObject.Find("/UI/CnvPaused/BtnRestart").GetComponent<Button>().onClick.AddListener(restartGame);
        GameObject.Find("/UI/CnvPaused/BtnQuit").GetComponent<Button>().onClick.AddListener(quitGame);
    }

    private void quitGame()
    {
        SceneManager.LoadScene("SceneGameMenu");
    }

    private void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void playGame()
    {
        GameObject.Find("/UI/CnvPaused").GetComponent<Canvas>().enabled = false;
        Time.timeScale = 1;
    }

    private void pauseGame()
    {
        if(Time.timeScale == 0)
        {
            GameObject.Find("/UI/CnvPaused").GetComponent<Canvas>().enabled = false;
            Time.timeScale = 1;
        } else
        {
            GameObject.Find("/UI/CnvPaused").GetComponent<Canvas>().enabled = true;
            Time.timeScale = 0;
        }
    }
}
