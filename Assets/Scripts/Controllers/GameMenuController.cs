using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("/CanvasMenu/BtnMenuPlay").GetComponent<Button>().onClick.AddListener(goToSceneGamePlay);
        GameObject.Find("/CanvasMenu/BtnMenuQuit").GetComponent<Button>().onClick.AddListener(quitGame);
    }

    public void goToSceneGamePlay()
    {
        Debug.Log("Loading SceneGamePlay");
        SceneManager.LoadScene("SceneLevel1");
    }
    public void quitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }
}
