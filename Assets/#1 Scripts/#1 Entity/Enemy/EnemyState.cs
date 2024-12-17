using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    private Enemy _enemy;
    Animator animator;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (_enemy.IsContainState(EnemyStates.IsMove))
        {
            animator.SetBool("walk", true);
            Debug.Log("적 이동중");
        }
        if(!_enemy.IsContainState(EnemyStates.IsMove))
        {
            animator.SetBool("walk", false);
            Debug.Log("적 이동 안함");
        }
        if (_enemy.IsContainState(EnemyStates.IsAttacking))
        {
            animator.SetTrigger("attack");
            Debug.Log("적 공격중");
        }
        if(!_enemy.IsContainState(EnemyStates.IsAttacking))
        {
            Debug.Log("적 공격 안함");
        }
        if (_enemy.IsContainState(EnemyStates.IsDie))
        {
            Debug.Log("적 사망");
        }
        if(!_enemy.IsContainState(EnemyStates.IsDie))
        {
            Debug.Log("적 사망 안함");
        }
    }
}
