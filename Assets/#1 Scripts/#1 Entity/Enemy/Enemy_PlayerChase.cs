using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_PlayerChase : MonoBehaviour
{
    private float speed = 3f; // 이동속도

    private Transform enemy; //에너미 위치변수
    private Transform player; //플레이어 위치변수

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
        transform.position = Vector2.MoveTowards(enemy.position, player.position, speed * Time.deltaTime); //플레이어한테 이동
    }
}
