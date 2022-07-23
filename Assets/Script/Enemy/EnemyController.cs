using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject Player;

    Player player;
    Enemy enemy;

    void Awake()
    {
        player = Player.GetComponent<Player>();
        enemy = GetComponent<Enemy>();
    }

    void Update()
    {
        EnemyMove();
    }

    void EnemyMove()
    {
        Vector3 dir = player.transform.position - transform.position;
        dir = dir.normalized;

        transform.position += dir * enemy.GetMoveSpeed() * Time.deltaTime;
    }

}
