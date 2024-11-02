using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safezone : MonoBehaviour
{
    Player _player;
    // Start is called before the first frame update
    void Start()
    {
        // 씬 내에 존재하는 Player 객체를 자동으로 찾아 할당
        _player = FindObjectOfType<Player>();
        if (_player == null)
        {
            Debug.LogError("Player 객체를 찾을 수 없습니다. 씬에 Player가 존재하는지 확인하세요.");
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    
    void OnTriggerEnter2D(Collider2D coll) //충돌 발생
    {
        Debug.Log("Test");
    }
    void OnTriggerStay2D(Collider2D coll)
    {
        Debug.Log("켜저 있음");
        _player.RecoveryHp(0.25f);
    }

    void OnTriggerExit2D(Collider2D coll)
    {
       
    }
}
