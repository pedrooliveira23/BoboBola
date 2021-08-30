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

    public void goToContinueGamePlay(int sceneIndex)
    {
        string sceneName = System.IO.Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(sceneIndex));
        Debug.Log("Loading scene: " + sceneName);
        SceneManager.LoadScene(sceneName);
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
