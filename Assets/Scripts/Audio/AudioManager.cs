using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource audio_source_bgm;
    [SerializeField] private AudioSource audio_source_fx;
    [SerializeField] private AudioSource audio_source_enemy_fx;

    [SerializeField] private AudioClip map_1_bgm_clip;
    [SerializeField] private AudioClip button_click;
    [SerializeField] private AudioClip button_click_1;
    [SerializeField] private AudioClip button_click_2;
    [SerializeField] private AudioClip arrow_shot;
    public static AudioManager Instance;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("More than one AudioManager Instance");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        audio_source_bgm.clip = map_1_bgm_clip;
        audio_source_bgm.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayButtonClick()
    {
        audio_source_fx.clip = button_click;
        audio_source_fx.Play();
    }
    public void PlayButtonClick2()
    {
        audio_source_fx.clip = button_click_1;
        audio_source_fx.Play();
    }
    public void PlayButtonClick3()
    {
        audio_source_fx.clip = button_click_2;
        audio_source_fx.Play();
    }
    public void PlayArrowSound()
    {
        audio_source_fx.clip = arrow_shot;
        audio_source_fx.Play();
    }
    public void MusicVolume(float volume)
    {
        audio_source_bgm.volume = volume;
    }

    public void SFXVolume(float volume)
    {
        audio_source_fx.volume = volume;
    }

}
