using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Dead : MonoBehaviour
{
    private Enemy testEnemy;
    void Awake()
    {
        testEnemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if(testEnemy.GetHp() <= 0)
        {
            testEnemy.AddState(EnemyStates.IsDie);
        }
    }   
}
