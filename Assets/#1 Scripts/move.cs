using System.Collections;
using UnityEngine;
using System;
using EnemyOwnedStates;

public class move : MonoBehaviour
{
    Vector2 inputVec;
    float speed = 3;
    Rigidbody2D rigid;
    public bool knuck = false;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");
        skilluse();
    }
    void FixedUpdate()
    {
        if (knuck)
        {
            Invoke("movement", 2);
        }
        else
        {
            movement();
        }
        
    }

    void movement()
    {
        Vector2 nextvec = inputVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextvec);
    }
    void skilluse()
    {
        if (Input.GetKeyDown("y"))
        {
            knuck = true;
        }
        else
        {
            knuck = false;
        }
    }

}

