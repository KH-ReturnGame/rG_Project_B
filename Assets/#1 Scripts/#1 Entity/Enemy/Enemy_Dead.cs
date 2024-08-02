using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Dead : MonoBehaviour
{
   
    Rigidbody2D rigid;

    private Enemy testEnemy;
    void Awake()
    {
        testEnemy = GetComponent<Enemy>();
        rigid = GetComponent<Rigidbody2D>();

        testEnemy.Setup(testEnemy._maxHp);
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        if(testEnemy.GetHp() <= 0)
        {
            testEnemy.AddState(EnemyStates.IsDie);
        }
        else if(testEnemy.GetHp() > 0 && !testEnemy.IsContainState(EnemyStates.IsKicked))
        {
            testEnemy.RemoveState(EnemyStates.IsDie);
            rigid.velocity = new Vector2(-3, rigid.velocity.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "trap")
        {
            testEnemy.TakeDamage(10);
            rigid.AddForce(new Vector2(10,5), ForceMode2D.Impulse);
        }
    }

   
}
