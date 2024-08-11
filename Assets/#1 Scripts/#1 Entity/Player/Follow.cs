using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public SpriteRenderer _playerfilp;
    public Transform _playerTransform;
    private SpriteRenderer spriteRenderer;
    public float radius;
    void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        // 마우스의 월드 좌표를 얻어옵니다.
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Z 축의 값을 고정합니다. 2D이기 때문에 Z 축은 0으로 설정합니다.
        mousePosition.z = 0;

        // 플레이어 플립이랑 방향 똑같이
        spriteRenderer.flipX = _playerfilp.flipX;

         // 플레이어와의 거리 계산
        Vector3 direction = mousePosition - _playerTransform.position;
        float distance = direction.magnitude;

        // 최대 거리를 초과할 경우
        if (distance > radius)
        {
            // 최대 거리 내에서 마우스를 따라가도록 위치를 조정
            direction = direction.normalized; // 방향 벡터를 정규화
            transform.position = _playerTransform.position + direction * radius;
        }
        else
        {
            // 최대 거리를 초과하지 않으면 마우스를 그대로 따라갑니다.
            transform.position = mousePosition;
        }
    }
}
