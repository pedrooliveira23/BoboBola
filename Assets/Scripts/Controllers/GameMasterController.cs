using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameMasterController : MonoBehaviour
{
    private GameObject player;
    private Camera cam;
    private GameMasterModel gameMasterModel;
    void Start()
    {
        gameMasterModel = GetComponent<GameMasterModel>();
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("/GameObjects/Player");
        cam = GameObject.Find("/Main Camera").GetComponent<Camera>();
        try {
            cam.transform.position = new Vector3(player.transform.position.x + 9, cam.transform.position.y, player.transform.position.z - 14);
        } catch
        {
            throw new NotImplementedException();
        }
    }

    public void MoveToGameOverScene()
    {
        gameMasterModel.LastLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene("SceneGameOver");
    }

    public void MoveToNextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex + 1 < SceneManager.sceneCountInBuildSettings)
        {
            try
            {
                SaveGameDAO.GetInstance().Update(new SaveGameModel(SceneManager.GetActiveScene().buildIndex+1));
            } catch(FileNotFoundException)
            {
                SaveGameDAO.GetInstance().Create(new SaveGameModel(SceneManager.GetActiveScene().buildIndex + 1));
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        } else
        {
            MoveToGameOverScene();
        }
    }

    public int getLastLevel()
    {
        return gameMasterModel.LastLevel;
    }
}
