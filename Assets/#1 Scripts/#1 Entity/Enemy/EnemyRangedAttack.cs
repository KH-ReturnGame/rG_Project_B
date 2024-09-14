using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangedAttack : MonoBehaviour
{
    private float distance;
    private Transform enemy; 
    public Transform player; 
    public float enemyx; // 에너미 x좌표
    public float playerx; // 플레이어 x좌표

    [SerializeField]
    private GameObject bulletPrefab;

    private bool isFiring = false;

    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        distance = gameObject.GetComponent<Enemy_RangedPlayerChase>().distance;
        player = gameObject.GetComponent<Enemy_RangedPlayerChase>().player;
        enemy = gameObject.GetComponent<Enemy_RangedPlayerChase>().enemy;

        playerx = player.position.x;
        enemyx = enemy.position.x;

        if (distance <= 3 && !isFiring)
        {
            InvokeRepeating("Fire", 1f, 3f);
            isFiring = true;
        }
    }

    private void Fire()
    {
        if (enemyx < playerx)
        {
         GameObject clone_bullet = Instantiate(bulletPrefab, new Vector3(transform.position.x + 1.2f, transform.position.y, transform.position.z) , transform.rotation);
        }
        else if(enemyx > playerx)
        {
         GameObject clone_bullet = Instantiate(bulletPrefab, new Vector3(transform.position.x -  1.2f, transform.position.y, transform.position.z), transform.rotation);
        }
        Debug.Log("Fire");
        // 총알 생성

    }
}
