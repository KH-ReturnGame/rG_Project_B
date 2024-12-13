using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollapseBoom : MonoBehaviour
{
    public GameObject[] Collapses;
    public float spawnRange = 1.0f; // 생성 범위 설정
    Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.IsContainState(EnemyStates.IsDie)) // 나중에 죽었을 때 발동
        {
            StartCoroutine(Boom());
        }
    }

    IEnumerator Boom()
    {
        yield return new WaitForSeconds(1.5f);
        // Collapses 배열의 각 오브젝트를 랜덤 위치에서 생성
        foreach (GameObject collapse in Collapses)
        {
            // 생성 범위 내 랜덤 위치 설정
            Vector3 randomPosition = transform.position + new Vector3(
                Random.Range(-spawnRange, spawnRange),
                Random.Range(-spawnRange, spawnRange),
                Random.Range(-spawnRange, spawnRange)
            );
            // 오브젝트 생성
            Instantiate(collapse, randomPosition, Quaternion.identity);
        }

        // 현재 오브젝트 삭제
        Destroy(gameObject);

        yield return null;
    }
}
