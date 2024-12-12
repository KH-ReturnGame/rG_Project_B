using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFly : MonoBehaviour
{
    private Rigidbody2D rb;
    private float FlyHeight = 2f; // 부양 거리
    private Enemy _enemy;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _enemy = GetComponent<Enemy>();
    }

    void Update()
    {
        if (!_enemy.IsContainState(EnemyStates.IsDie) && !_enemy.IsContainState(EnemyStates.IsFly))
        {
            Hover();
        }
        else if (_enemy.IsContainState(EnemyStates.IsDie))
        {
            FallToGround();
        }
    }

    void Hover()
    {
        rb.gravityScale = 0f;
       
    }

    void FallToGround()
    {
        rb.gravityScale = 1f;
         _enemy.RemoveState(EnemyStates.IsFly);
    }

}
