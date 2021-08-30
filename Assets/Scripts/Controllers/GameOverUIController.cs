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
        sceneManagerController = GetComponent<SceneManagerController>();
        gameMasterController = GameObject.Find("/GameMaster").GetComponent<GameMasterController>();
        int levelIndex;
        try
        {
            levelIndex = SaveGameDAO.GetInstance().Read().LevelIndex;
            if(gameMasterController.getLastLevel() < levelIndex)
            {
                levelIndex = 1;
            }
        }
        catch (FileNotFoundException)
        {
            levelIndex = 1;
        }
        GameObject.Find("/CanvasMenu/BtnRestart").GetComponent<Button>().onClick.AddListener(delegate { sceneManagerController.goToContinueGamePlay(levelIndex); });
        GameObject.Find("/CanvasMenu/BtnQuit").GetComponent<Button>().onClick.AddListener(sceneManagerController.goToSceneGameMenu);

        GameObject.Find("/CanvasMenu/TxtLevel").GetComponent<Text>().text = "Nível Alcançado: " + (gameMasterController.getLastLevel() == 0 ? "Máximo" : gameMasterController.getLastLevel().ToString());
    }

}
