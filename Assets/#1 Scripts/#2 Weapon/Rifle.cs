using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : Weapon
{
    //기본 무기 설정
    private void Start()
    {
        //무기 데미지 30, 0에서 최대 과열정도까지 증가하는데 걸리는 시간 10초
        Setup(30,0.1f,10f);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            AddState(WeaponStates.IsShootingRifle);
            IncreaseOverheatingDiscrete();
        }
        if(Input.GetMouseButtonUp(0))
        {
            RemoveState(WeaponStates.IsShootingRifle);
        }
    }
}