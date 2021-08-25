using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlayUIController : MonoBehaviour
{
    private GameMasterController gameMasterController;
    private SceneManagerController sceneManagerController;
    private Text scoreText;
    void Start()
    {
        sceneManagerController = GetComponent<SceneManagerController>();
        gameMasterController = GameObject.Find("/GameMaster").GetComponent<GameMasterController>();
        scoreText = GameObject.Find("UI/CnvGamePlay/TxtScore").GetComponent<Text>();
        GameObject.Find("/UI/CnvPaused").GetComponent<Canvas>().enabled = false;
        GameObject.Find("/UI/CnvGamePlay/BtnPause").GetComponent<Button>().onClick.AddListener(pauseGame);
        GameObject.Find("/UI/CnvPaused/BtnPlay").GetComponent<Button>().onClick.AddListener(playGame);
        GameObject.Find("/UI/CnvPaused/BtnRestart").GetComponent<Button>().onClick.AddListener(sceneManagerController.goToSceneGamePlay);
        GameObject.Find("/UI/CnvPaused/BtnQuit").GetComponent<Button>().onClick.AddListener(sceneManagerController.goToSceneGameMenu);
        setInitialValues();
    }

    private void Update()
    {
        try
        {
            scoreText.text = "Pontuação: " + gameMasterController.getScore() + "\nNível: " + SceneManager.GetActiveScene().buildIndex;
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
