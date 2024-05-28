using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerUIManager : MonoBehaviour
{
    [SerializeField] private Image main_panel;
    [SerializeField] private Image properties_panel;
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
        PauseGame();
    }
    public void BackToMainPanel()
    {
        properties_panel.gameObject.SetActive(false);
        ResumeGame();
    }
    public void ExitGame()
    {
        SceneManager.LoadScene("Scene1");
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
}
