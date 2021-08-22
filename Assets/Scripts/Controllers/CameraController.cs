using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject player;
    void Start()
    {
        player = GameObject.Find("GameObjects/Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x + 9, transform.position.y, player.transform.position.z - 14);
    }
}
