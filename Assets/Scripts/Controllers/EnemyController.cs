using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameObject player;
    private EnemyModel enemy;
    private Rigidbody enemyRb;

    private void Start()
    {
        player = GameObject.Find("/GameObjects/Player");
        enemy = GetComponent<EnemyModel>();
        enemyRb = GetComponent<Rigidbody>();
        SetDefaultValues();
    }
    void Update()
    {
        Vector3 movePosition = transform.position;
        movePosition.x = Mathf.MoveTowards(transform.position.x, player.transform.position.x, enemy.Velocity);
        movePosition.z = Mathf.MoveTowards(transform.position.z, player.transform.position.z, enemy.Velocity);
        movePosition.y = Mathf.MoveTowards(transform.position.y, 0.5f, enemy.Velocity);
        enemyRb.MovePosition(movePosition);
        enemyRb.velocity = new Vector3(enemyRb.velocity.x, 0.5f, enemyRb.velocity.z);
        enemyRb.velocity = enemyRb.velocity.normalized * enemy.velocity;
    }

    private void SetDefaultValues()
    {
        enemy.Velocity = 0.075f;
    }
}
