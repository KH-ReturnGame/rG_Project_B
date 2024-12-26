using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_MeleePlayerChase : MonoBehaviour
{
    private float speed = 3f;

    private Transform enemy;
    private Transform player;

    void Start()
    {
        enemy = this.gameObject.GetComponent<Transform>();
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    
    void Update()
    {
        ChasingPlayer();
    }

    private void ChasingPlayer()
    {
        transform.position = Vector2.MoveTowards(enemy.position, player.position, speed * Time.deltaTime); //�÷��̾����� �̵�
    }
}
