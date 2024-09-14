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
            Debug.Log("������");
        }
        if(!isMoving)
        {
            _enemy.RemoveState(EnemyStates.IsMove);
            Debug.Log("�ȿ�����");
        }

        if (isAttacking)
        {
            _enemy.AddState(EnemyStates.IsAttacking);
            Debug.Log("������");
        }
        if(!isAttacking)
        {
            _enemy.RemoveState(EnemyStates.IsAttacking);
            Debug.Log("������ �ƴ�");
        }
    }
}
