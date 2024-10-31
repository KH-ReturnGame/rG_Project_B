using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangedAttack : MonoBehaviour
{
    public Transform player;
    private float distance;
    private Enemy _enemy;
    
    [SerializeField]
    private GameObject bulletPrefab;

    void Start()
    {
        _enemy = GetComponent<Enemy>();        
        distance = gameObject.GetComponent<Enemy_RangedPlayerChase>().distance;
        player = gameObject.GetComponent<Enemy_RangedPlayerChase>().player;
    }

    // Update is called once per frame
    void Update()
    {
        if (distance <= 5 && !_enemy.IsContainState(EnemyStates.IsMove) && !_enemy.IsContainState(EnemyStates.IsAttacking))
        {
            StartCoroutine(Fire());
            _enemy.AddState(EnemyStates.IsAttacking);
        }
        
        if (distance > 5 || _enemy.IsContainState(EnemyStates.IsMove))
        {
            // ������ �������� ������ �ݺ� ȣ���� ����ϰ� �÷��׸� �ʱ�ȭ
            StopCoroutine(Fire());
            _enemy.RemoveState(EnemyStates.IsAttacking);
        }
    }

    IEnumerator Fire()
    {
        if (transform.position.x < player.position.x)
        {
            GameObject clone_bullet = Instantiate(bulletPrefab, new Vector3(transform.position.x + 1.2f, transform.position.y, transform.position.z) , transform.rotation);
        }
        else if(transform.position.x > player.position.x)
        {
            GameObject clone_bullet = Instantiate(bulletPrefab, new Vector3(transform.position.x -  1.2f, transform.position.y, transform.position.z), transform.rotation);
        }
        Debug.Log("Fire");

        yield return new WaitForSeconds(1.5f);

        StartCoroutine(Fire());

        yield return null;
        // �Ѿ� ����
    }
}
