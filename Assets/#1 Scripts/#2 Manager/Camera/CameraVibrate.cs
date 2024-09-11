using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraVibrate : MonoBehaviour
{
    CinemachineVirtualCamera _Vcam;
    CinemachineBasicMultiChannelPerlin _VcamNoise;
    void Start()
    {
        _Vcam = GetComponent<CinemachineVirtualCamera>();
        _VcamNoise = _Vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        TriggerShake(1, 2.5f, 2.5f, 5); // 카메라 진동 테스트용
    }

    // 사용법
    // TriggerShake(int하고싶은 진동의 종류(번호), float진동의 세기, float진동의 주기, float진동의 지속시간);
    public void TriggerShake(int i, float AmpGain, float FreGain, float waitsec)
    {
        switch (i)
        {
            case 1:// case별로 진동 정도 구분, 진동 세기는 위 2,3번째 매개변수와 GetFloat를 이용.
                StartCoroutine(Shake(AmpGain, FreGain, waitsec));
                break;
            default:
                Debug.Log("그런 카메라 쉐이크는 없다");
                break;
        }
    }

    //이런거 만들어서 어떻게 진동할지 구현해놓고 위의 switch case문에 저장? 해놓으면 댐니다.
    IEnumerator Shake(float Amp, float Fre, float waitseconds)
    {
        float GainRate = PlayerPrefs.GetFloat("VibrateRate");

        _VcamNoise.m_AmplitudeGain = Amp * GainRate;
        _VcamNoise.m_FrequencyGain = Fre * GainRate;

        yield return new WaitForSeconds(waitseconds);// waitseconds 매개변수

        _VcamNoise.m_AmplitudeGain = 0f;
        _VcamNoise.m_FrequencyGain = 0f;
    }
}