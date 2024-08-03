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
            dashdirection = 2;
        }
        else if (Mathf.Abs(X) - Mathf.Abs(Y) >= 0 && X < 0)
        {
            dashdirection = 4;
        }
        else if (Mathf.Abs(X) - Mathf.Abs(Y) < 0 && Y >= 0)
        {
            dashdirection = 3;
        }
        else if (Mathf.Abs(X) - Mathf.Abs(Y) < 0 && Y < 0)
        {
            dashdirection = 1;
        }
        //Debug.Log("direction: " + dashdirection);
        Debug.Log(dashdirection);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ground")
        {
            if (dashdirection == 1)
            {
                rigid.AddForce(Vector2.down * knuckbackpower, ForceMode2D.Impulse);
                Debug.Log("asdf");
            }
            else if (dashdirection == 2)
            {
                rigid.AddForce(Vector2.right * knuckbackpower, ForceMode2D.Impulse);
                Debug.Log("asdf");
            }
            else if (dashdirection == 3)
            {
                rigid.AddForce(Vector2.up * knuckbackpower, ForceMode2D.Impulse);
                Debug.Log("asdf");
            }
            else if (dashdirection == 4)
            {
                rigid.AddForce(Vector2.left * knuckbackpower, ForceMode2D.Impulse);
                Debug.Log("asdf");
            }
        }
    }
}
