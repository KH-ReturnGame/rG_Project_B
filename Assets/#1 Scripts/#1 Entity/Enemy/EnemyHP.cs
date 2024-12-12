using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    private float currentHp;
    private Enemy _enemy;
    void Start()
    {
         _enemy = GetComponent<Enemy>();
        currentHp = _enemy.GetHp();

         _enemy.RemoveState(EnemyStates.IsDie); 
    }

    // Update is called once per frame
    void Update()
    {
        currentHp = _enemy.GetHp();

        if (currentHp <= 0 && !_enemy.IsContainState(EnemyStates.IsDie))
        {
            _enemy.AddState(EnemyStates.IsDie); 
        }
    }
}
