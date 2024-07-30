using System.Collections;
using UnityEngine;
using System;
using EnemyOwnedStates;

public class move : MonoBehaviour
{
    Vector2 inputVec;
    float speed = 3;
    Rigidbody2D rigid;
    bool skill = false;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");
    }
    void FixedUpdate()
    {
        Vector2 nextvec = inputVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextvec);
    }
}

