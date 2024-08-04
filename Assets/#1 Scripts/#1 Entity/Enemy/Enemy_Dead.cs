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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "trap")
        {
            // testEnemy.TakeDamage(10);
            // 죽음 사운드 재생
            // 스프라이트 변경
            rigid.velocity = new Vector2(0, 0);
            rigid.constraints = RigidbodyConstraints2D.FreezeRotation;
            testEnemy.AddState(EnemyStates.IsDie);
            Debug.Log("으악 시발 원통하다");
        }
        else if(collision.gameObject.tag == "wall")
        {
            // testEnemy.TakeDamage(10);
            // 죽음 사운드 재생
            // 스프라이트 변경
            rigid.velocity = new Vector2(0, rigid.velocity.y);
            rigid.constraints = RigidbodyConstraints2D.FreezeRotation;
            testEnemy.AddState(EnemyStates.IsStun);
            Debug.Log("으악 시발 벽이다");
        }
    }

   
}
