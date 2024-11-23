using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tentacle_Mid : MonoBehaviour
{
    private tentacle_Detect playerDetect;
    public GameObject Mid_tentacle;
    public GameObject playerAttack;


    void Awake()
    {
        gameObject.SetActive(true);
        playerDetect = GameObject.Find("Detect_tentacle").GetComponent<tentacle_Detect>();
        if (playerDetect == null)
        {
            Debug.Log("tentacle_Detect 컴포넌트를 찾을 수 없습니다!");
        }
    }

    void Update()
    {
        if (playerDetect.GetAttackox() == 1)
        {
            Debug.Log("공격함");
            playerAttack.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("lllllll");
        }
    }

}
