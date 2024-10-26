using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    private Enemy _enemy;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
    }
    void Update()
    {
        if (_enemy.IsContainState(EnemyStates.IsMove))
        {
            Debug.Log("������");
        }
        if(!_enemy.IsContainState(EnemyStates.IsMove))
        {
            Debug.Log("�ȿ�����");
        }

        if (_enemy.IsContainState(EnemyStates.IsAttacking))
        {
            Debug.Log("������");
        }
        if(!_enemy.IsContainState(EnemyStates.IsAttacking))
        {
            Debug.Log("������ �ƴ�");
        }
    }
}
