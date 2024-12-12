using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangedAttack : MonoBehaviour
{
    public Transform player;
    private float distance;
    private Enemy _enemy;
    private Coroutine fireCoroutine; // 실행 중인 Fire 코루틴의 참조
    [SerializeField]
    private GameObject bulletPrefab;

    void Start()
    {
        _enemy = GetComponent<Enemy>();        
        player = gameObject.GetComponent<Enemy_RangedPlayerChase>().player;
    }

    // Update is called once per frame
    void Update()
    {
        if (distance <= 5f 
        && !_enemy.IsContainState(EnemyStates.IsDie) 
        && !_enemy.IsContainState(EnemyStates.IsMove) 
        && !_enemy.IsContainState(EnemyStates.IsAttacking))
        {
            // 플레이어와 거리가 5 이하면 발사, Fire 코루틴이 실행 중이지 않다면 시작
            if (fireCoroutine == null)
            {
                fireCoroutine = StartCoroutine(Fire());
                _enemy.AddState(EnemyStates.IsAttacking);
            }
        }
        else if (distance > 5f || _enemy.IsContainState(EnemyStates.IsMove) || _enemy.IsContainState(EnemyStates.IsDie))
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

    IEnumerator Fire()
    {
        while (true) // 무한 반복 루프
        {
            if (_enemy.IsContainState(EnemyStates.IsDie)) // 적이 사망했는지 확인
            {
                yield break; // 코루틴 종료
            }

            // 총알 발사
            if (transform.position.x < player.position.x)
            {
                Instantiate(bulletPrefab, new Vector3(transform.position.x + 1.2f, transform.position.y, transform.position.z), transform.rotation);
            }
            else
            {
                Instantiate(bulletPrefab, new Vector3(transform.position.x - 1.2f, transform.position.y, transform.position.z), transform.rotation);
            }
            Debug.Log("Fire");

            yield return new WaitForSeconds(1.5f); // 1.5초 대기 후 반복
        }
    }
}
