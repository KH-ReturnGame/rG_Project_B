using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knuckback : MonoBehaviour
{
    Rigidbody2D rigid;
    int MyX, MyY;
    int OtherX, OtherY;
    int knuckbackpower = 10;
    int dashdirection;//1À§2¿Þ3¾Æ·¡4¿À¸¥
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
        
        if ((OtherX - MyX)-(OtherX - MyY)>=0)
        {
            dashdirection = 2;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ground")
        {
            Debug.Log("³Ë¹é!");
        }
    }
}
