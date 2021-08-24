using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    private PlayerModel player;
    private ScoreModel scoreModel;
    private Rigidbody playerRb;
    public GameObject springBox;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerModel>();
        scoreModel = GameObject.Find("/ScoreCounter").GetComponent<ScoreModel>();
        playerRb = player.GetComponent<Rigidbody>();
        SetDefaultValues();
        InitiateRandomMoviment();
        StartCoroutine("updateScore");
    }

    // Update is called once per frame
    void Update()
    {
        playerRb.velocity = new Vector3(playerRb.velocity.x, 1f, playerRb.velocity.z);
        playerRb.velocity = playerRb.velocity.normalized * player.velocity;
        transform.position = new Vector3(transform.position.x, 1f, transform.position.z);
        SpawnSpringBox();
    }

    public int getScore()
    {
        return scoreModel.Score;
    }
    IEnumerator updateScore()
    {
        while (true) { 
            yield return new WaitForSeconds(1f);
            scoreModel.Score--;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene("SceneGameMenu");
        }

        if (collision.gameObject.tag == "Finish")
        {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                scoreModel.Score += 1000;
        }
    }
    private void SetDefaultValues()
    {
        player.Velocity = 5.0f;

        if (SceneManager.GetActiveScene().name == "SceneLevel1") {
            scoreModel.Score = 1000;
        }

    }


    private void SpawnSpringBox()
    {
        if (Input.GetMouseButtonDown(0) && Time.timeScale == 1)
        {
            RaycastHit hit;
            //Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit) && hit.collider.tag == "Terrain")
            {
                Instantiate(springBox, new Vector3(hit.point.x, 0.5f, hit.point.z), Quaternion.identity);
            }
        }
    }

    private void InitiateRandomMoviment()
    {

        playerRb.velocity = new Vector3(player.Velocity * -1, 1f, Random.Range(player.Velocity * -1, player.Velocity));
    }

}
