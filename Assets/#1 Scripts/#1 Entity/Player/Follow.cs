using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public SpriteRenderer _playerfilp;
    private SpriteRenderer spriteRenderer;
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

        // 오브젝트의 위치를 마우스 위치로 설정합니다.
        transform.position = mousePosition;
        
        // 플레이어 플립이랑 방향 똑같이
        spriteRenderer.flipX = _playerfilp.flipX;
    }
}
