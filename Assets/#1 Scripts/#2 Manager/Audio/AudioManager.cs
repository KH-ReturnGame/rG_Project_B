using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public float MasterVolume;

    [Header("BGM")]
    public AudioClip bgmClip;
    public float bgmVolume;
    AudioSource bgmPlayer;
    AudioHighPassFilter bgmFilter;

    [Header("SFX")]
    public AudioClip[] sfxClips;
    public float sfxVolume;
    public int channels;
    AudioSource[] sfxPlayers;
    int channelIndex;
    public enum SFX_enum {Damage = 0, Dash}    

    void Awake()
    {
        instance = this;
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Init()
    {
        // 마스터
        MasterVolume = 0.5f;
        // 배경음
        GameObject bgmObject = new GameObject("BgmPLayer");
        bgmObject.transform.parent = transform;
        bgmPlayer = bgmObject.AddComponent<AudioSource>();
        bgmPlayer.playOnAwake = false;
        bgmPlayer.loop = true;
        bgmPlayer.volume = bgmVolume * MasterVolume;
        bgmPlayer.clip = bgmClip;
        bgmFilter = Camera.main.GetComponent<AudioHighPassFilter>();

        // 효과음
        GameObject sfxObject = new GameObject("sfxPlayer");
        sfxObject.transform.parent = transform;
        sfxPlayers = new AudioSource[channels];
        for (int index = 0; index < sfxPlayers.Length; index++)
        {
            sfxPlayers[index] = sfxObject.AddComponent<AudioSource>();
            sfxPlayers[index].playOnAwake = false;
            sfxPlayers[index].bypassListenerEffects = true;
            sfxPlayers[index].loop = false;
            sfxPlayers[index].volume = sfxVolume * MasterVolume;
        }
    }

    public void PlayBGM(bool isPlay)
    {
        bgmPlayer.volume = bgmVolume * MasterVolume;
        if(isPlay)
        {
            bgmPlayer.Play();
        }
        else
        {
            bgmPlayer.Stop();
        }
    }

    public void FilterBGM(bool isFilter)
    {
        bgmFilter.enabled = isFilter;
    }

    public void PlaySFX(SFX_enum sfx_enum)
    {
        for(int i = 0; i < sfxPlayers.Length; i++)
        {
            sfxPlayers[i].volume = sfxVolume * MasterVolume;
            int loopIndex = (i + channelIndex) % sfxPlayers.Length;
            if(sfxPlayers[loopIndex].isPlaying)
                continue;

            channelIndex = loopIndex;
            sfxPlayers[loopIndex].clip = sfxClips[(int)sfx_enum];
            sfxPlayers[loopIndex].Play();
            Debug.Log(loopIndex);
            break;
        }
    }
}
