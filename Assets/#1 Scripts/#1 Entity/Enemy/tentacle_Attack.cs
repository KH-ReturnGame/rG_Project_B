using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tentacle_Attack : MonoBehaviour
{    
    private tentacle_Detect playerDetect;
    private tentacle_Mid playerMid;
    public GameObject Attack_tentacle;
    void Awake()
    {
        
        playerDetect = GameObject.Find("Detect_tentacle").GetComponent<tentacle_Detect>();
        playerMid = GameObject.Find("Mid_tentacle").GetComponent<tentacle_Mid>();

        if (playerDetect == null)
        {
            Debug.Log("tentacle_Detect 컴포넌트를 찾을 수 없습니다!");
        }
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (playerDetect.GetAttackox() == 1)
        {
            Debug.Log("공격성공");
            Destroy(gameObject,1f);
        }
        
    }
    
}
