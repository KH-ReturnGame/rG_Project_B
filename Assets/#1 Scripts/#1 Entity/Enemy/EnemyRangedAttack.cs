using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangedAttack : MonoBehaviour
{
    private Transform enemy;
    public Transform player;

    private float distance;
    public float enemyx; // 에너미 x좌표
    public float playerx; // 플레이어 x좌표

    private Enemy _enemy;

    [SerializeField]
    private GameObject bulletPrefab;

    public bool isAttacking = false;

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

        if (distance <= 5 && !_enemy.IsContainState(EnemyStates.IsMove))
        {
            InvokeRepeating("Fire", 1f, 3f);
        }
    }

    private void Fire()
    {
        isAttacking = true;
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
        isAttacking = false;

    }
}
