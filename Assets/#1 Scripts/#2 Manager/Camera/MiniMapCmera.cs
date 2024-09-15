using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapCmera : MonoBehaviour
{
    private Transform player;  // 플레이어의 Transform을 연결

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void LateUpdate()
    {
        // 플레이어의 위치를 따라 카메라 이동
        Vector3 newPosition = player.position;
        newPosition.z = transform.position.z;  // 카메라의 Z축은 고정
        transform.position = newPosition;
    }
}