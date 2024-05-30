using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMana : MonoBehaviour
{
    public void Update()
    {
        SetManaBar();
        SetEaseManaBar();
        GainMana(5f);
    }
    public void GainMana(float value)
    {
        PlayerManager.Instance.AddMana(value * Time.deltaTime);
    }
    public void DecreaseMana(float value)
    {
        PlayerManager.Instance.MinusMana(value);

    }
    private void SetManaBar()
    {
        float mana_fill = PlayerManager.Instance.CurrentMana / PlayerManager.Instance.Mana;
        PlayerUIManager.Instance.mana_text.text = $"{Math.Round(PlayerManager.Instance.CurrentMana)} / {Math.Round(PlayerManager.Instance.Mana)}";
        if (mana_fill != PlayerUIManager.Instance.mana_bar.fillAmount)
        {
            PlayerUIManager.Instance.mana_bar.fillAmount = mana_fill;
        }
    } 
    private void SetEaseManaBar()
    {
        if (PlayerUIManager.Instance.erase_mana_bar.fillAmount != PlayerUIManager.Instance.mana_bar.fillAmount)
        {
            PlayerUIManager.Instance.erase_mana_bar.fillAmount = Mathf.MoveTowards(PlayerUIManager.Instance.erase_mana_bar.fillAmount, PlayerUIManager.Instance.mana_bar.fillAmount, PlayerUIManager.Instance.LerpSpeed * Time.deltaTime);
        }
    }
}
