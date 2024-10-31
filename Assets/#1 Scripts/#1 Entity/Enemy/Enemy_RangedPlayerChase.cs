using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_RangedPlayerChase : MonoBehaviour
{
    private float speed = 3f; // �̵��ӵ�
    public float distance; // �Ÿ�
    public float limit_distance;
    public Transform player; // �÷��̾� ��ġ����
    private Enemy _enemy;

    void Start()
    {
        limit_distance = 5f;
        player = GameObject.Find("player(Clone)").transform;
        _enemy = GetComponent<Enemy>();
    }

    
    void Update()
    {
        distance = Vector2.Distance(player.position, transform.position); // �÷��̾���� �Ÿ� ����

        if (distance > limit_distance && !_enemy.IsContainState(EnemyStates.IsMove))
        {
            StartCoroutine(ChasingPlayer());
        }
    }

    IEnumerator ChasingPlayer()
    {
        yield return new WaitForSeconds(0.5f);

        _enemy.AddState(EnemyStates.IsMove);
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime); // �÷��̾����� �̵�
        _enemy.RemoveState(EnemyStates.IsMove);

        yield return null;
    }
}
