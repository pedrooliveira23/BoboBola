using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    private PlayerModel player;
    private Rigidbody playerRb;
    public GameObject springBox;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerModel>();
        playerRb = player.GetComponent<Rigidbody>();
        SetDefaultValues();
        InitiateRandomMoviment();
    }

    // Update is called once per frame
    void Update()
    {
        playerRb.velocity = new Vector3(playerRb.velocity.x, 0.5f, playerRb.velocity.z);
        playerRb.velocity = playerRb.velocity.normalized * player.velocity;
        transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
        SpawnSpringBox();
    }

    private void SetDefaultValues()
    {
        player.Velocity = 5.0f;
    }


    private void SpawnSpringBox()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Make Whatever a Raycast layer or if you don't want it just exclude it
            if (Physics.Raycast(ray, out hit))
            {
                Instantiate(springBox, new Vector3(hit.point.x, 0.5f, hit.point.z), Quaternion.identity);
            }
        }
    }

    private void InitiateRandomMoviment()
    {

        playerRb.velocity = new Vector3(player.Velocity * -1, 0.5f, Random.Range(player.Velocity * -1, player.Velocity));
    }

}
