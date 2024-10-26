using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundSliderUI : MonoBehaviour
{
    [SerializeField] private AudioMixer m_AudioMixer;
    [SerializeField] private Slider m_MusicMasterSlider;
    [SerializeField] private Slider m_MusicBGMSlider;
    [SerializeField] private Slider m_MusicEffectSlider;
 
    private void Awake()
    {
        m_MusicMasterSlider.onValueChanged.AddListener(SetMasterVolume);
        m_MusicBGMSlider.onValueChanged.AddListener(SetMusicVolume);
        m_MusicEffectSlider.onValueChanged.AddListener(SetEffectVolume);
        
        m_MusicMasterSlider.value = AudioManager.instance.MasterVolume;
        m_MusicBGMSlider.value = AudioManager.instance.bgmVolume;
        m_MusicEffectSlider.value = AudioManager.instance.sfxVolume;
    }
 
    public void SetMasterVolume(float volume)
    {
        AudioManager.instance.MasterVolume = volume;
    }
 
    public void SetMusicVolume(float volume)
    {
        if(volume < 0.05)
        {
            volume = 0;
        }
        AudioManager.instance.bgmVolume = volume / AudioManager.instance.MasterVolume;
    }
 
    public void SetEffectVolume(float volume)
    {
        if(volume < 0.05)
        {
            volume = 0;
        }
        AudioManager.instance.sfxVolume = volume / AudioManager.instance.MasterVolume;
    }  
}