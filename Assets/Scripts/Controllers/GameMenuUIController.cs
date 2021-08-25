using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenuUIController : MonoBehaviour
{
    private SceneManagerController sceneManagerController;
    void Start()
    {
        sceneManagerController = GetComponent<SceneManagerController>();
        GameObject.Find("/CanvasMenu/BtnMenuPlay").GetComponent<Button>().onClick.AddListener(sceneManagerController.goToSceneGamePlay);
        GameObject.Find("/CanvasMenu/BtnMenuQuit").GetComponent<Button>().onClick.AddListener(sceneManagerController.quitGame);
    }
}
