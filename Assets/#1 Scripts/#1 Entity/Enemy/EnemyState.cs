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
            Debug.Log("움직임");
        }
        if(!_enemy.IsContainState(EnemyStates.IsMove))
        {
            Debug.Log("안움직임");
        }

        if (_enemy.IsContainState(EnemyStates.IsAttacking))
        {
            Debug.Log("공격중");
        }
        if(!_enemy.IsContainState(EnemyStates.IsAttacking))
        {
            Debug.Log("공격중 아님");
        }
    }
}
