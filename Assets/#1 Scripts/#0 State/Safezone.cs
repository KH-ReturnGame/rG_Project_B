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
    
   void OnTriggerEnter2D(Collider2D coll)
       {
           // 플레이어가 안전지대에 들어왔을 때만 로그 출력
           if (coll.CompareTag("Player"))
           {
               Debug.Log("Player entered Safezone.");
           }
       }
   
    void OnTriggerStay2D(Collider2D coll)
       {
           // Player 태그가 붙은 객체와만 상호작용하도록 설정
           if (coll.CompareTag("Player") && _player != null)
           {
               Debug.Log("Player is in Safezone. Recovering health.");
               _player.RecoveryHp(0.25f * Time.deltaTime * 10   ); // 체력 회복
           }
       }
   
       void OnTriggerExit2D(Collider2D coll)
       {
           // 안전지대에서 나갈 때 메시지 출력
           if (coll.CompareTag("Player"))
           {
               Debug.Log("Player exited Safezone.");
           }
       }
}
