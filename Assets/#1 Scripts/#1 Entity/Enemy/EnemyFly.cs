using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFly : MonoBehaviour
{
    private Rigidbody2D rb;
    private Enemy _enemy;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _enemy = GetComponent<Enemy>();
        Hover();
    }

    void Update()
    {

    }

    void Hover()
    {
        rb.gravityScale = -0.25f;
        Invoke("FallToGround", 0.5f);
    }

    void FallToGround()
    {
        rb.gravityScale = 0.5f;
        _enemy.RemoveState(EnemyStates.IsFly);
        Invoke("Hover", 0.5f);
    }

}
