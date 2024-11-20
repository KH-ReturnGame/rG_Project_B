using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tentacle_Attack : MonoBehaviour
{
    private tentacle_Detect playerDetect;
    public GameObject Attack_tentacle;

    void Awake()
    {
        playerDetect = GameObject.Find("Detect_tentacle").GetComponent<tentacle_Detect>();
        
        if (playerDetect == null)
        {
            Debug.LogError("tentacle_Detect 컴포넌트를 찾을 수 없습니다!");
        }
    }

    void Update()
    {
        if (playerDetect.GetAttackox() == 1)
        {
            Debug.Log("공격함");
            gameObject.SetActive(false);
        }
    }

}
