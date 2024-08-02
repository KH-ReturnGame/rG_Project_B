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
    public float x, y;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        skilluse();
        x = rigid.position.x;
        y = rigid.position.y;
    }
    void FixedUpdate()
    {
        
        movement();
    }

    void movement()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");
        Vector2 HorizontalVec = new Vector2(rigid.position.x + inputVec.x, rigid.position.y);
        Debug.DrawRay(HorizontalVec, Vector2.down, new Color(0, 1, 0));
        RaycastHit2D HrayHit = Physics2D.Raycast(HorizontalVec, Vector2.down, 1, LayerMask.GetMask("platform"));
        Vector2 VerticalVec = new Vector2(rigid.position.x, rigid.position.y + inputVec.y);
        Debug.DrawRay(VerticalVec, Vector2.left, new Color(0, 1, 0));
        RaycastHit2D VrayHit = Physics2D.Raycast(VerticalVec, Vector2.left, 1, LayerMask.GetMask("platform"));
        if (HrayHit.collider == null)
        {
            inputVec.x = 0;
        }
        if (VrayHit.collider == null)
        {
            inputVec.y = 0;
        }
        Vector2 nextvec = inputVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextvec);
        Debug.Log(inputVec.x);
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

