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
    [SerializeField] private Image main_panel;
    [SerializeField] private Image properties_panel;
    [SerializeField] private Image setting_panel;
    [SerializeField] private Slider music_slider;
    [SerializeField] private Slider sound_slider;
    [SerializeField] private TextMeshProUGUI music_percentage_text;
    [SerializeField] private TextMeshProUGUI sound_percentage_text;
    private bool isPaused = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenPropertiesPanel()
    {
        properties_panel.gameObject.SetActive(true);
        AudioManager.Instance.PlayButtonClick();
        PauseGame();
    }
    public void BackToMainPanel()
    {
        properties_panel.gameObject.SetActive(false);
        AudioManager.Instance.PlayButtonClick();
        ResumeGame();
    }
    public void ExitGame()
    {
        AudioManager.Instance.PlayButtonClick();
        DataPersistaceManager.instance.SaveGame();
        SceneManager.LoadScene("Scene1");
    }
    public void OpenSettingPanel()
    {
        setting_panel.gameObject.SetActive(true);
        AudioManager.Instance.PlayButtonClick2();
    }
    public void CloseSettingPanel()
    {
        setting_panel.gameObject.SetActive(false);
        AudioManager.Instance.PlayButtonClick3();
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
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
