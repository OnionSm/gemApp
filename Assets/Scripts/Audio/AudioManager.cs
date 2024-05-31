using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource audio_source_bgm;
    public AudioSource AudioSourceBGM
    {
        get { return audio_source_bgm; }
        set { audio_source_bgm = value;}
    }

    [SerializeField] private AudioSource audio_source_fx;
    public AudioSource AudioSourceFx
    {
        get { return audio_source_fx; }
        set { audio_source_fx = value; }
    }
    [SerializeField] private AudioSource audio_source_enemy_fx;
    public AudioSource AudioSourceEnemyFx
    {
        get { return audio_source_enemy_fx; }
        set { audio_source_enemy_fx = value;}
    }

    [SerializeField] private Audios all_audio_configs;

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
        all_audio_configs = InGameManager.Instance.GetAllAudiosConfigs();
        if(all_audio_configs != null ) 
        {
            string name = SceneManager.GetActiveScene().name;
            if (name.Equals("SampleScene"))
            {
                PlayBGM("darkrise_battle_theme");
            }
            else if(name.Equals("Scene1"))
            {
                PlayBGM("main_menu_theme");
                Debug.Log("Play main menu theme");
            }
        }
    }
    // Update is called once per frame
   
    public void PlayBGM(string clip)
    {
        AudioClip audioClip = null;
        for(int i = 0; i < all_audio_configs.config_for_all_audios.Count; i++) 
        {
            if (all_audio_configs.config_for_all_audios[i].name.Equals(clip))
            {
                audioClip = all_audio_configs.config_for_all_audios[i].clip;
                break;
            }
        }
        if (audioClip != null)
        {
            audio_source_bgm.clip = audioClip;
            audio_source_bgm.Play();
        }
    }
    public void PlaySFXSound(string clip)
    {
        AudioClip audioClip = null;
        for (int i = 0; i < all_audio_configs.config_for_all_audios.Count; i++)
        {
            if (all_audio_configs.config_for_all_audios[i].name.Equals(clip))
            {
                audioClip = all_audio_configs.config_for_all_audios[i].clip;
                break;
            }
        }
        if (audioClip != null)
        {
            audio_source_fx.clip = audioClip;
            audio_source_fx.Play();
        }
    }
    public void PlayEnemySFXSound(string clip)
    {
        AudioClip audioClip = null;
        for (int i = 0; i < all_audio_configs.config_for_all_audios.Count; i++)
        {
            if (all_audio_configs.config_for_all_audios[i].name.Equals(clip))
            {
                audioClip = all_audio_configs.config_for_all_audios[i].clip;
                break;
            }
        }
        if (audioClip != null)
        {
            audio_source_enemy_fx.clip = audioClip;
            audio_source_enemy_fx.Play();
        }
    }
    
    public void MusicVolume(float volume)
    {
        audio_source_bgm.volume = volume/100f;
    }

    public void SFXVolume(float volume)
    {
        audio_source_fx.volume = volume;
        audio_source_enemy_fx.volume = volume/100f;
    }
}
