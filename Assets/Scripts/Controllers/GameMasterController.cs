using System;
using System.Collections;
using System.Collections.Generic;
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
        StartCoroutine("updateScore");
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

    private void OnEnable()
    {
        gameMasterModel = GetComponent<GameMasterModel>();
        gameMasterModel.ScoreCountable = true;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (SceneManager.GetActiveScene().name == "SceneLevel1")
        {
            gameMasterModel.Score = 1000;
        }
    }

    public int getScore()
    {
        return gameMasterModel.Score;
    }

    public void setScore(int value)
    {
        gameMasterModel.Score = value;
    }
    IEnumerator updateScore()
    {
        while (gameMasterModel.ScoreCountable)
        {
            yield return new WaitForSeconds(1f);
            gameMasterModel.Score--;
        }
    }

    public void MoveToGameOverScene()
    {
        gameMasterModel.LastLevel = SceneManager.GetActiveScene().buildIndex;
        gameMasterModel.ScoreCountable = false;
        SceneManager.LoadScene("SceneGameOver");
    }

    public void MoveToNextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex + 1 < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            gameMasterModel.Score += 1000;
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
