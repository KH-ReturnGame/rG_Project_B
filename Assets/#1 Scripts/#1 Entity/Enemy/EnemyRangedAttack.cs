using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangedAttack : MonoBehaviour
{
    private float distance;

    [SerializeField]
    private GameObject bulletPrefab;


    void Start()
    {
        distance = gameObject.GetComponent<Enemy_RangedPlayerChase>().distance;
    }

    // Update is called once per frame
    void Update()
    {
        if (distance <= 3)
        {
            

            Fire();
        }
    }

    private void Fire()
    {
        // ÃÑ¾Ë »ý¼º
        
    }
}
