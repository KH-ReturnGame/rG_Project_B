using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_RangedPlayerChase : MonoBehaviour
{
    private float speed = 3f; // �̵��ӵ�
    public float distance; // �Ÿ�

    private Transform enemy; // ���ʹ� ��ġ����
    private Transform player; // �÷��̾� ��ġ����

    void Start()
    {
        enemy = this.gameObject.GetComponent<Transform>();
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
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
