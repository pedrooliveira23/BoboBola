using System;
using System.Collections;
using System.Collections.Generic;
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
        GameObject.Find("/CanvasMenu/BtnRestart").GetComponent<Button>().onClick.AddListener(sceneManagerController.goToSceneGamePlay);
        GameObject.Find("/CanvasMenu/BtnQuit").GetComponent<Button>().onClick.AddListener(sceneManagerController.quitGame);

        GameObject.Find("/CanvasMenu/TxtLevel").GetComponent<Text>().text = "Nível Alcançado: " + gameMasterController.getLastLevel();
    }

}
