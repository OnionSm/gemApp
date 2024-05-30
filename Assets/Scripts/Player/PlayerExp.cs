using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerExp : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        UpdateExpBar();
    }
    private void UpdateExpBar()
    {

        float fill = PlayerManager.Instance.CurrentExp / PlayerManager.Instance.ExpMax;
        PlayerUIManager.Instance.exp_fill.fillAmount = fill;
        /*Debug.Log($"EXP FILL {fill}");*/
    }
    public void AddExp(float value)
    {
        PlayerManager.Instance.AddExp(value);
    }
    public void SetTextLevel(float value)
    {
        if(PlayerUIManager.Instance.lv_text.text != null)
            PlayerUIManager.Instance.lv_text.text = $"{value}";
    }
}
