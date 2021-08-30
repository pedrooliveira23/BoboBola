using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUIController : MonoBehaviour
{
    private SceneManagerController sceneManagerController;
    private GameMasterController gameMasterController;
    void Start()
    {
        int levelIndex;
        try
        {
            levelIndex = SaveGameDAO.GetInstance().Read().LevelIndex;
        }
        catch (FileNotFoundException)
        {
            levelIndex = 1;
        }
        sceneManagerController = GetComponent<SceneManagerController>();
        gameMasterController = GameObject.Find("/GameMaster").GetComponent<GameMasterController>();
        GameObject.Find("/CanvasMenu/BtnRestart").GetComponent<Button>().onClick.AddListener(delegate { sceneManagerController.goToContinueGamePlay(levelIndex); });
        GameObject.Find("/CanvasMenu/BtnQuit").GetComponent<Button>().onClick.AddListener(sceneManagerController.quitGame);

        GameObject.Find("/CanvasMenu/TxtLevel").GetComponent<Text>().text = "N�vel Alcan�ado: " + (gameMasterController.getLastLevel() == 0 ? "M�ximo" : gameMasterController.getLastLevel().ToString());
    }

}
