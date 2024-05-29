using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;
using TMPro;
using System;
using Unity.VisualScripting;

public class MainScreenUIManager : MonoBehaviour
{
    [SerializeField] private Image main_panel;
    [SerializeField] private TextMeshProUGUI main_panel_username_text;
    [SerializeField] private TextMeshProUGUI main_panel_lv_text;
    [SerializeField] private Image char_history_panel;
    [SerializeField] private TextMeshProUGUI char_his_upper_text;
    [SerializeField] private Image history_add_char_panel;
    [SerializeField] private Image choose_char_panel;
    [SerializeField] private Image char_detail;
    [SerializeField] private Image input_name_panel;
    [SerializeField] private TextMeshProUGUI input_field;
    [SerializeField] private Image invalid_input_panel;
    [SerializeField] private Image nickname_used_panel;
    [SerializeField] private List<CharHistoryUI> list_char_history;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Application.persistentDataPath);
        if (DataPersistaceManager.instance.SlotChoosen != null)
        {
            main_panel_username_text.text = DataPersistaceManager.instance.SlotChoosen.character_name;
            main_panel_lv_text.text = $"Lv {DataPersistaceManager.instance.SlotChoosen.level}";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ClickSwitchHero()
    {
        main_panel.gameObject.SetActive(false);
        char_history_panel.gameObject.SetActive(true);
        char_his_upper_text.text = $" Your Character ({DataPersistaceManager.instance.gameData.Count}/5)";
        if(DataPersistaceManager.instance.gameData.Count>=5)
        {
            history_add_char_panel.gameObject.SetActive(false);
        }
        for(int i = 0; i< DataPersistaceManager.instance.gameData.Count; i++) 
        {
            SaveSlot temp = DataPersistaceManager.instance.gameData[i];
            list_char_history[i].panel.gameObject.SetActive(true);
            list_char_history[i].username.text = temp.character_name;
            list_char_history[i].level.text = $"Level {temp.level}";
        }
    }
    public void ClickHeroInHistory(int value)
    {
        char_history_panel.gameObject.SetActive(false);
        main_panel.gameObject.SetActive(true);
        DataPersistaceManager.instance.SlotChoosen = DataPersistaceManager.instance.gameData[value];
        main_panel_username_text.text = DataPersistaceManager.instance.SlotChoosen.character_name;
        main_panel_lv_text.text = $"Lv {DataPersistaceManager.instance.SlotChoosen.level}";
    }
    public void ClickDeleteHeroHistory(int value)
    {

    }
    public void ClickCharHistoryBack()
    {
        char_history_panel.gameObject.SetActive(false);
        main_panel.gameObject.SetActive(true);
    }
    public void ClickAddHero()
    {
        char_history_panel.gameObject.SetActive(false);
        choose_char_panel.gameObject.SetActive(true);
    }
    public void ClickAddCharBack()
    {
        choose_char_panel.gameObject.SetActive(false);
        char_history_panel.gameObject.SetActive(true);
    }
    public void HeroDetail()
    {
        choose_char_panel.gameObject.SetActive(false);
        char_detail.gameObject.SetActive(true);
    }
    public void HeroDetailBack()
    {
        char_detail.gameObject.SetActive(false);
        choose_char_panel.gameObject.SetActive(true);
    }
    public void SelectButton()
    {
        char_detail.gameObject.SetActive(false);
        input_name_panel.gameObject.SetActive(true);
    }
    public void InputNickNameBack()
    {
        input_name_panel.gameObject.SetActive(false);
        char_detail.gameObject.SetActive(true);
    }
    public void ApplyButton()
    {
        string pattern = "^[a-zA-Z0-9]{3,16}";
        string input = input_field.text;

        if(Regex.IsMatch(input, pattern))
        {
            if (!DataPersistaceManager.instance.CheckNameFileExist(input))
            {
                DataPersistaceManager.instance.CreateNewUser(input);
                LoadScene();
            }
            else
            {
                OpenNicknameUsedPanel();
            }
        }
        else
        {
            invalid_input_panel.gameObject.SetActive(true);
        }
    }
    public void CloseInvalidPanel()
    {
        invalid_input_panel.gameObject.SetActive(false);    
    }
    public void OpenNicknameUsedPanel()
    {
        nickname_used_panel.gameObject.SetActive(true);
    }
    public void CloseNicknameUsedPanel()
    {
        nickname_used_panel.gameObject.SetActive(false);
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

}
