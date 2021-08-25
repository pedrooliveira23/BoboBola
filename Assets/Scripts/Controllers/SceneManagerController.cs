using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerController : MonoBehaviour
{
    public void goToSceneGamePlay()
    {
        Debug.Log("Loading SceneGamePlay");
        SceneManager.LoadScene("SceneLevel1");
    }

    public void goToSceneGameMenu()
    {
        Debug.Log("Loading SceneGameMenu");
        SceneManager.LoadScene("SceneGameMenu");
    }

    public void quitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }
}
