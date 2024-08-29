using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_RangedPlayerChase : MonoBehaviour
{
    private float speed = 3f; // �̵��ӵ�
    public float distance; // �Ÿ�

    private Transform enemy; // ���ʹ� ��ġ����
    public Transform player; // �÷��̾� ��ġ����

    void Start()
    {
        enemy = this.transform;
        player = GameObject.FindWithTag("Player").transform;
    }

    
    void Update()
    {
         distance = Vector2.Distance(player.position, enemy.position); // �÷��̾���� �Ÿ� ����

        if (distance > 3)
        {
            ChasingPlayer();
        }
    }

    private void ChasingPlayer()
    {
        transform.position = Vector2.MoveTowards(enemy.position, player.position, speed * Time.deltaTime); // �÷��̾����� �̵�
    }
}
