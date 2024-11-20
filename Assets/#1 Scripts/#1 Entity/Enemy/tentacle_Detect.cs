using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tentacle_Detect : MonoBehaviour
{
    private int Attack_ox = 0;  
    public float detectionRadius = 1f;
    public Transform player; 
    public LayerMask playerLayer;

    public int GetAttackox()
    {
        return Attack_ox;
    }

    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("플레이어 감지");
        }
    }

}
