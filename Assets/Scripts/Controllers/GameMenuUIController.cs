using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenuUIController : MonoBehaviour
{
    private SceneManagerController sceneManagerController;
    private SaveGameModel saveGame;
    void Start()
    {
        verifySaveGame();
        sceneManagerController = GetComponent<SceneManagerController>();
        GameObject.Find("/CanvasMenu/BtnMenuPlay").GetComponent<Button>().onClick.AddListener(sceneManagerController.goToSceneGamePlay);
        GameObject.Find("/CanvasMenu/BtnContinue").GetComponent<Button>().onClick.AddListener(delegate { sceneManagerController.goToContinueGamePlay(saveGame.LevelIndex); });
        GameObject.Find("/CanvasMenu/BtnMenuQuit").GetComponent<Button>().onClick.AddListener(sceneManagerController.quitGame);
    }

    private void verifySaveGame()
    {
        GameObject btnContinue = GameObject.Find("/CanvasMenu/BtnContinue");
        try {
            saveGame = SaveGameDAO.GetInstance().Read();
            Debug.Log("Save game found.");
            btnContinue.SetActive(true);
        } catch (FileNotFoundException)
        {
            btnContinue.SetActive(false);
            Debug.Log("Save game not found.");
        }
    }
}
