using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_MeleAttack : MonoBehaviour
{
    Enemy _enemy;
    public GameObject AttackRange;
    public float AttackLatency;
    public float AttackDuring;
    Animator anim;
    Coroutine fireCoroutine;
    Enemy_RangedPlayerChase _PlayerChase;
    // Start is called before the first frame update
    void Start()
    {
        _enemy = GetComponent<Enemy>();
        anim = GetComponent<Animator>();
        _PlayerChase = GetComponent<Enemy_RangedPlayerChase>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_PlayerChase.distance <= 1f 
        && !_enemy.IsContainState(EnemyStates.IsDie) 
        && !_enemy.IsContainState(EnemyStates.IsMove) 
        && !_enemy.IsContainState(EnemyStates.IsAttacking))
        {
            // 플레이어와 거리가 5 이하면 발사, Fire 코루틴이 실행 중이지 않다면 시작
            if (fireCoroutine == null)
            {
                fireCoroutine = StartCoroutine(Attack());
                _enemy.AddState(EnemyStates.IsAttacking);
            }
        }
        else if (_PlayerChase.distance > 5f || _enemy.IsContainState(EnemyStates.IsMove) || _enemy.IsContainState(EnemyStates.IsDie))
        {
            // Fire 코루틴이 실행 중이라면 멈춤
            if (fireCoroutine != null)
            {
                StopCoroutine(fireCoroutine);
                fireCoroutine = null; // 참조 초기화
                _enemy.RemoveState(EnemyStates.IsAttacking);
            }
        }
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(AttackLatency);

        AttackRange.SetActive(true);
        anim.SetTrigger("attack");
        
        yield return new WaitForSeconds(AttackDuring);
        
        AttackRange.SetActive(false);

        yield return null;
        StartCoroutine(Attack());
    }
}
