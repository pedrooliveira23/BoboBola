using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    private PlayerModel player;
    private Rigidbody playerRb;
    public GameObject springBox;
    private GameMasterController gameMasterController;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerModel>();
        playerRb = player.GetComponent<Rigidbody>();
        gameMasterController = GameObject.Find("/GameMaster").GetComponent<GameMasterController>();
        SetDefaultValues();
        InitiateRandomMoviment();
    }

    // Update is called once per frame
    void Update()
    {
        playerRb.velocity = new Vector3(playerRb.velocity.x, 1f, playerRb.velocity.z);
        playerRb.velocity = playerRb.velocity.normalized * player.Velocity;
        transform.position = new Vector3(transform.position.x, 1f, transform.position.z);
        SpawnSpringBox();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            gameMasterController.MoveToGameOverScene();
        }

        if (collision.gameObject.tag == "Finish")
        {
            gameMasterController.MoveToNextLevel();
        }
    }
    private void SetDefaultValues()
    {
        player.Velocity = 5.0f;
        player.CanCreateSpringBox = true;
    }


    private void SpawnSpringBox()
    {
        if (Input.GetMouseButtonDown(0) && Time.timeScale == 1)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit) && (hit.collider.tag != "Player" && hit.collider.tag != "Enemy") && player.CanCreateSpringBox)
            {
                Instantiate(springBox, new Vector3(hit.point.x, 0.5f, hit.point.z), Quaternion.identity);
            }
        }
    }

    private void InitiateRandomMoviment()
    {

        playerRb.velocity = new Vector3(player.Velocity * -1, 1f, Random.Range(player.Velocity * -1, player.Velocity));
    }

    public void setCanCreateSpringBox(bool value)
    {
        player.CanCreateSpringBox = value;
    }

    public bool getCanCreateSpringBox()
    {
        return player.CanCreateSpringBox;
    }
}