using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_MeleePlayerChase : MonoBehaviour
{
    private float speed = 3f; // �̵��ӵ�

    private Transform enemy; //���ʹ� ��ġ����
    private Transform player; //�÷��̾� ��ġ����

    void Start()
    {
        enemy = this.gameObject.GetComponent<Transform>();
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    
    void Update()
    {
        ChasingPlayer();
        Debug.Log(player.position);
    }

    private void ChasingPlayer()
    {
        transform.position = Vector2.MoveTowards(enemy.position, player.position, speed * Time.deltaTime); //�÷��̾����� �̵�
    }
}
