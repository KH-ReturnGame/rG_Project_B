using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_RangedPlayerChase : MonoBehaviour
{
    private float speed = 3f; // 이동 속도
    public float distance; // 플레이어와의 거리
    public float limit_distance;
    public Transform player; // 플레이어 위치 가져오기
    private Enemy _enemy;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        limit_distance = 5f;
        player = GameObject.Find("player(Clone)").transform;
        _enemy = GetComponent<Enemy>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        distance = Vector2.Distance(player.position, transform.position); // 거리 측정

        if (distance > limit_distance && !_enemy.IsContainState(EnemyStates.IsDie))
        {
            StartCoroutine(ChasingPlayer());
        }
        if (distance <= limit_distance || _enemy.IsContainState(EnemyStates.IsDie))
        {
            //StopCoroutine(ChasingPlayer()); 불안해서 일단 작동중인거 다 멈추는걸로 해놨어 준혁아
            StopAllCoroutines();
            _enemy.RemoveState(EnemyStates.IsMove);
        }

        if (transform.position.x < player.position.x) // 에너미 플립
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }

    IEnumerator ChasingPlayer()
    {
        yield return new WaitForSeconds(0.5f);

        Debug.Log("?????????????????");
        _enemy.AddState(EnemyStates.IsMove);
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime); // �÷��̾����� �̵�
        
        yield return null;
    }
}
