using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_RangedPlayerChase : MonoBehaviour
{
    private float speed = 3f; // �̵��ӵ�
    public float distance; // �Ÿ�

    public Transform enemy; // ���ʹ� ��ġ����
    public Transform player; // �÷��̾� ��ġ����

    private Enemy _enemy;

    public bool isMoving = false;
    private bool isAttacking;
    void Start()
    {
        enemy = transform;
        player = GameObject.Find("player(Clone)").transform;

    }

    
    void Update()
    {
      

        distance = Vector2.Distance(player.position, enemy.position); // �÷��̾���� �Ÿ� ����

        if (distance > 5)
        {
            ChasingPlayer();
        }
    }

    private void ChasingPlayer()
    {
        if(!_enemy.IsContainState(EnemyStates.IsAttacking))
        {
            isMoving = true;
            transform.position = Vector2.MoveTowards(enemy.position, player.position, speed * Time.deltaTime); // �÷��̾����� �̵�
            isMoving = false;
        }
    }
}
