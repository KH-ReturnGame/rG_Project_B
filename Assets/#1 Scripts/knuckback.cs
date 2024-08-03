using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knuckback : MonoBehaviour
{
    Rigidbody2D rigid;
    public GameObject player;
    float MyX, MyY;
    float OtherX, OtherY;
    float X, Y;
    float knuckbackpower = 100;
    int dashdirection;//1위2왼3아래4오른
    int Xdirection, Ydirection;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        MyX = rigid.position.x;
        MyY = rigid.position.y;
        OtherX = player.GetComponent<Transform>().position.x;
        OtherY = player.GetComponent<Transform>().position.y;
        X = MyX - OtherX;
        Y = MyY - OtherY;
        if (Mathf.Abs(X) - Mathf.Abs(Y) >= 0 && X >= 0)
        {
            Xdirection = 1;
        }
        else if (Mathf.Abs(X) - Mathf.Abs(Y) >= 0 && X < 0)
        {
            Xdirection = -1;
        }
        else if (Mathf.Abs(X) - Mathf.Abs(Y) < 0 && Y >= 0)
        {
            Ydirection = 1;
        }
        else if (Mathf.Abs(X) - Mathf.Abs(Y) < 0 && Y < 0)
        {
            Ydirection = -1;
        }
        //Debug.Log("direction: " + dashdirection);
        //Debug.Log(dashdirection);
    }

    void FixedUpdate()
    {
        Vector2 HorizontalVec = new Vector2(rigid.position.x + Xdirection, rigid.position.y);
        Debug.DrawRay(HorizontalVec, Vector2.down, new Color(0, 1, 0));
        RaycastHit2D HrayHit = Physics2D.Raycast(HorizontalVec, Vector2.down, 1, LayerMask.GetMask("platform"));
        Vector2 VerticalVec = new Vector2(rigid.position.x, rigid.position.y + Ydirection);
        Debug.DrawRay(VerticalVec, Vector2.left, new Color(0, 1, 0));
        RaycastHit2D VrayHit = Physics2D.Raycast(VerticalVec, Vector2.left, 1, LayerMask.GetMask("platform"));
        Vector2 MHorizontalVec = new Vector2(rigid.position.x + Xdirection, rigid.position.y);
        Debug.DrawRay(MHorizontalVec, Vector2.down, new Color(0, 1, 0));
        RaycastHit2D MHrayHit = Physics2D.Raycast(MHorizontalVec, Vector2.down, 1, LayerMask.GetMask("platform"));
        Vector2 MVerticalVec = new Vector2(rigid.position.x, rigid.position.y + Ydirection);
        Debug.DrawRay(MVerticalVec, Vector2.left, new Color(0, 1, 0));
        RaycastHit2D MVrayHit = Physics2D.Raycast(MVerticalVec, Vector2.left, 1, LayerMask.GetMask("platform"));
        if (HrayHit.collider == null || VrayHit.collider == null || MHrayHit.collider == null || MVrayHit.collider == null)
        {
            rigid.velocity = new Vector2(0, 0);
            Xdirection = Ydirection = 0;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ground")
        {
            if (Ydirection == -1)
            {
                rigid.AddForce(Vector2.down * knuckbackpower, ForceMode2D.Impulse);
                Debug.Log("asdf");
            }
            else if (Xdirection == 1)
            {
                rigid.AddForce(Vector2.right * knuckbackpower, ForceMode2D.Impulse);
                Debug.Log("asdf");
            }
            else if (Ydirection == 1)
            {
                rigid.AddForce(Vector2.up * knuckbackpower, ForceMode2D.Impulse);
                Debug.Log("asdf");
            }
            else if (Xdirection == -1)
            {
                rigid.AddForce(Vector2.left * knuckbackpower, ForceMode2D.Impulse);
                Debug.Log("asdf");
            }
        }
    }
}
