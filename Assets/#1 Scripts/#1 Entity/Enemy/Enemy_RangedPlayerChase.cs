using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_RangedPlayerChase : MonoBehaviour
{
    private float speed = 3f; // 이동속도
    public float distance; // 거리

    public Transform enemy; // 에너미 위치변수
    public Transform player; // 플레이어 위치변수

    private Enemy _enemy;

    void Start()
    {
        enemy = transform;
        player = GameObject.Find("player(Clone)").transform;
        _enemy = GetComponent<Enemy>();
    }

    
    void Update()
    {
      

        distance = Vector2.Distance(player.position, enemy.position); // 플레이어와의 거리 측정

        if (distance > 5)
        {
            ChasingPlayer();
        }
    }

    private void ChasingPlayer()
    {
        if(!_enemy.IsContainState(EnemyStates.IsAttacking))
        {
            _enemy.AddState(EnemyStates.IsMove);
            transform.position = Vector2.MoveTowards(enemy.position, player.position, speed * Time.deltaTime); // 플레이어한테 이동
            _enemy.RemoveState(EnemyStates.IsMove);
        }
    }
}
