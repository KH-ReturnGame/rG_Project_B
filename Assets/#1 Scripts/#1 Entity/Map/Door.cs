using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public List<GameObject> enemies; // 문 주변의 적들을 리스트로 받을 수 있습니다.
    private Collider2D doorCollider; // 문에 붙은 콜라이더를 참조합니다.
    Animator doorAnimator;

    void Start()
    {
        doorCollider = GetComponent<Collider2D>();
        doorAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        // 모든 적이 죽었는지 체크
        if (AreAllEnemiesDead())
        {
            // 모든 적이 죽었으면 문을 닫고, 콜라이더를 비활성화합니다.
            doorCollider.enabled = false;
            doorAnimator.enabled = true;
            StartCoroutine(Bye());
        }
    }

    // 모든 적이 죽었는지 체크하는 함수
    bool AreAllEnemiesDead()
    {
        foreach (GameObject enemy in enemies)
        {
            Enemy enemyScript = enemy.GetComponent<Enemy>();
            if (enemyScript != null && !enemyScript.IsContainState(EnemyStates.IsDie))
            {
                return false; // 하나라도 죽지 않았다면 false 반환
            }
        }
        return true; // 모든 적이 죽었으면 true 반환
    }

    IEnumerator Bye()
    {
        yield return new WaitForSeconds(0.5f);

        Destroy(gameObject);

        yield return null;
    }
}