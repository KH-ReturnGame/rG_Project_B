using System.Collections;
using UnityEngine;

public class muzzle : MonoBehaviour
{
    [SerializeField]
    private Transform player; // 플레이어의 Transform
    public float rotationSpeed = 5f; // 회전 속도 (초당 회전 속도)

    void Start()
    {
        // 플레이어 찾기
        player = GameObject.Find("player(Clone)").GetComponent<Transform>();
    }

    void Update()
    {
        // 플레이어와의 방향 계산
        Vector3 direction = player.position - transform.position;

        // Z축 회전만 적용하도록 평면상의 방향 벡터 계산
        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Z축 회전만 적용 (y축과 X축은 기존 값 유지)
        transform.rotation = Quaternion.Euler(0, 0, targetAngle);
    }
}
