using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("BGM")]
    public AudioClip bgmClip;
    public float bgmVolume;
    AudioSource bgmPlayer;

    [Header("SFX")]
    public AudioClip[] sfxClips;
    public float sfxVolume;
    public int channels;
    AudioSource[] sfxPlayers;
    int channelIndex;

    public enum SFX_enum {Damage, Dash}    

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
        // 배경음
        GameObject bgmObject = new GameObject("BgmPLayer");
        bgmObject.transform.parent = transform;
        bgmPlayer = bgmObject.AddComponent<AudioSource>();
        bgmPlayer.playOnAwake = false;
        bgmPlayer.loop = true;
        bgmPlayer.volume = bgmVolume;
        bgmPlayer.clip = bgmClip;

        // 효과음
        GameObject sfxObject = new GameObject("sfxPlayer");
        sfxObject.transform.parent = transform;
        sfxPlayers = new AudioSource[channels];
        for (int index = 0; index < sfxPlayers.Length; index++)
        {
            sfxPlayers[index] = sfxObject.AddComponent<AudioSource>();
            sfxPlayers[index].playOnAwake = false;
            // sfxPlayers[index].loop = false;
            sfxPlayers[index].volume = sfxVolume;
            // sfxPlayers[index].clip = sfxClips[index];
        }
    }

    public void PlaySFX(SFX_enum sfx_enum)
    {
        for(int i = 0; i < sfxPlayers.Length; i++)
        {
            int loopIndex = (i + channelIndex) % sfxPlayers.Length;
            if(sfxPlayers[loopIndex].isPlaying)
                continue;
            
            channelIndex = loopIndex;
            sfxPlayers[loopIndex].clip = sfxClips[(int)sfx_enum];
            sfxPlayers[loopIndex].Play();
            break;
        }
    }
}
