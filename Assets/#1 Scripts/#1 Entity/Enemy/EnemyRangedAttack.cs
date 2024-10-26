using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangedAttack : MonoBehaviour
{
    private Transform enemy;
    public Transform player;

    private float distance;
    public float enemyx; // ���ʹ� x��ǥ
    public float playerx; // �÷��̾� x��ǥ

    private Enemy _enemy;

    [SerializeField]
    private GameObject bulletPrefab;

    void Start()
    {
        _enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = gameObject.GetComponent<Enemy_RangedPlayerChase>().distance;
        player = gameObject.GetComponent<Enemy_RangedPlayerChase>().player;
        enemy = gameObject.GetComponent<Enemy_RangedPlayerChase>().enemy;

        playerx = player.position.x;
        enemyx = enemy.position.x;

        if (distance <= 5 && !_enemy.IsContainState(EnemyStates.IsMove) && !_enemy.IsContainState(EnemyStates.IsAttacking))
        {
            InvokeRepeating("Fire", 1f, 3f);
        }
        else if (distance > 5 || _enemy.IsContainState(EnemyStates.IsMove) || _enemy.IsContainState(EnemyStates.IsAttacking))
        {
            // ������ �������� ������ �ݺ� ȣ���� ����ϰ� �÷��׸� �ʱ�ȭ
            CancelInvoke("Fire");
            _enemy.RemoveState(EnemyStates.IsAttacking);
        }
    }

    private void Fire()
    {
        _enemy.AddState(EnemyStates.IsAttacking);
        if (enemyx < playerx)
        {
         GameObject clone_bullet = Instantiate(bulletPrefab, new Vector3(transform.position.x + 1.2f, transform.position.y, transform.position.z) , transform.rotation);
        }
        else if(enemyx > playerx)
        {
         GameObject clone_bullet = Instantiate(bulletPrefab, new Vector3(transform.position.x -  1.2f, transform.position.y, transform.position.z), transform.rotation);
        }
        Debug.Log("Fire");
        // �Ѿ� ����
        

    }
}
