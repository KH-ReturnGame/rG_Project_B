using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    private Enemy _enemy;

    private bool isMoving;
    private bool isAttacking;
    private bool isAttacked;

    public void Start()
    {
        isMoving = gameObject.GetComponent<Enemy_RangedPlayerChase>().isMoving;
        isAttacking = gameObject.GetComponent<EnemyRangedAttack>().isAttacking;
        isAttacked = false;
    }

    void Update()
    {
        if (isMoving)
        {
            _enemy.AddState(EnemyStates.IsMove);
            Debug.Log("움직임");
        }
        if(!isMoving)
        {
            _enemy.RemoveState(EnemyStates.IsMove);
            Debug.Log("안움직임");
        }

        if (isAttacking)
        {
            _enemy.AddState(EnemyStates.IsAttacking);
            Debug.Log("공격중");
        }
        if(!isAttacking)
        {
            _enemy.RemoveState(EnemyStates.IsAttacking);
            Debug.Log("공격중 아님");
        }
    }
}
