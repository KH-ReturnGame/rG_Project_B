using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tentacle_Detect : MonoBehaviour
{
    private int Attack_check = 0;  
    public float detectionRadius = 1f;
    public Transform player; 
    public LayerMask playerLayer;
    
    public int GetAttackox()
    {
        return Attack_check;
    }

    void Update()
    {
        
    }
    //플레이어 인식하기
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("플레이어 감지");
            Attack_check = 1;
            gameObject.SetActive(false);

        }
    }

}
