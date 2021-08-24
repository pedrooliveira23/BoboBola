using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlayController : MonoBehaviour
{
    private PlayerController playerController;
    private Text scoreText;
    void Start()
    {
        playerController = GameObject.Find("/GameObjects/Player").GetComponent<PlayerController>();
        scoreText = GameObject.Find("UI/CnvGamePlay/TxtScore").GetComponent<Text>();
        GameObject.Find("/UI/CnvPaused").GetComponent<Canvas>().enabled = false;
        GameObject.Find("/UI/CnvGamePlay/BtnPause").GetComponent<Button>().onClick.AddListener(pauseGame);
        GameObject.Find("/UI/CnvPaused/BtnPlay").GetComponent<Button>().onClick.AddListener(playGame);
        GameObject.Find("/UI/CnvPaused/BtnRestart").GetComponent<Button>().onClick.AddListener(restartGame);
        GameObject.Find("/UI/CnvPaused/BtnQuit").GetComponent<Button>().onClick.AddListener(quitGame);
        setInitialValues();
    }

    private void Update()
    {
        try
        {
            scoreText.text = "Pontuação: " + playerController.getScore();
        } catch (NullReferenceException ex)
        {
            Debug.Log(ex.Message);
            scoreText.text = "Pontuação: 0";
        }
    }
    private void setInitialValues()
    {
        Time.timeScale = 1;
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
