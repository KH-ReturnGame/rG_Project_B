using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour
{
    private Enemy _enemy;
    Animator anim;
    [SerializeField]
    private GameObject bulletPrefab;
    public int fire_direc;
    // Start is called before the first frame update
    void Start()
    {
        _enemy = GetComponent<Enemy>();
        anim = GetComponent<Animator>();
        StartCoroutine(Fire());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Fire()
    {
        if (_enemy.IsContainState(EnemyStates.IsDie)) // 적이 사망했는지 확인
        {
            yield break; // 코루틴 종료
        }
        
        anim.SetTrigger("attack");
        
        Instantiate(bulletPrefab, new Vector3(transform.position.x + (fire_direc * 1.2f), transform.position.y, transform.position.z), transform.rotation);
        
        yield return new WaitForSeconds(1.5f); // 1.5초 대기 후 반복

        StartCoroutine(Fire());
    }
}
