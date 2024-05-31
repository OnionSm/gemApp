using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerUIManager : MonoBehaviour
{

    public static PlayerUIManager Instance;

    [Header("Panel")]
    public Image main_panel;
    public Image properties_panel;
    public Image setting_panel;
    public Image death_panel;

    [Header("Music Sound Slider")]
    public Slider music_slider;
    public Slider sound_slider;

    [Header("Music Sound Text")]
    public TextMeshProUGUI music_percentage_text;
    public TextMeshProUGUI sound_percentage_text;

    [Header("Speed of Eraser")]
    [SerializeField] [Range(0f,1f)] private float lerp_speed;
    public float LerpSpeed => lerp_speed;


    [Header("Health Bar")]
    public Image health_bar;
    public Image erase_health_bar;
    public TextMeshProUGUI health_text;
    

    [Header("Mana Bar")]
    [SerializeField] public Image mana_bar;
    public Image erase_mana_bar;
    public TextMeshProUGUI mana_text;
    

    [Header("Level and Exp")]
    public TextMeshProUGUI lv_text;
    public Image exp_fill;

    [Header("Coin and Gem")]
    public TextMeshProUGUI coin_text;
    public TextMeshProUGUI gem_text;


    protected void Awake()
    {
        if(PlayerUIManager.Instance == null)
        {
            PlayerUIManager.Instance = this;
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("More than one PlayerUIManager");
        }
    }

    void Start()
    {

        LoadInitialSceneUI();
    }
    private void LoadInitialSceneUI()
    {
        main_panel.gameObject.SetActive(true);
        properties_panel.gameObject.SetActive(false);
        setting_panel.gameObject.SetActive(false);
        death_panel.gameObject.SetActive(false);
    }
    // Update is called once per frame


    public void OpenPropertiesPanel()
    {
        properties_panel.gameObject.SetActive(true);
        AudioManager.Instance.PlaySFXSound("button0");
        PauseGame();
    }
    public void BackToMainPanel()
    {
        properties_panel.gameObject.SetActive(false);
        AudioManager.Instance.PlaySFXSound("button0");
        ResumeGame();
    }
    public void ExitGame()
    {
        AudioManager.Instance.PlaySFXSound("button0");
        DataPersistaceManager.instance.SaveGame();
        ScenesTrasitionManager.Instance.NextLevel("Scene1");
        ResumeGame();
    }
    public void OpenSettingPanel()
    {
        setting_panel.gameObject.SetActive(true);
        AudioManager.Instance.PlaySFXSound("button1");
    }
    public void CloseSettingPanel()
    {
        setting_panel.gameObject.SetActive(false);
        AudioManager.Instance.PlaySFXSound("button2");
    }
    public void OpenDeathPanel()
    {
        death_panel.gameObject.SetActive(true);
        PauseGame();
    }
    public void CloseDeathPanel()
    {
        ScenesTrasitionManager.Instance.NextLevel("SampleScene");
        ResumeGame();
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }
    public void MusicVolume()
    {
        AudioManager.Instance.MusicVolume(music_slider.value);
        music_percentage_text.text = $"{Math.Round(music_slider.value)}%";
    }
    public void SFXVolume()
    {
        AudioManager.Instance.SFXVolume(sound_slider.value);
        sound_percentage_text.text = $"{Math.Round(sound_slider.value)}%";
    }
}
