using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMana : MonoBehaviour
{
    public Image mana_bar;
    public Image erase_mana_bar;
    public float lerp_speed;
    [SerializeField] private TextMeshProUGUI mana_text;
    private void Awake()
    {

    }
    private void Start()
    {
        this.LoadComponent();
    }
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
    private void LoadComponent()
    {
        this.lerp_speed = 1f;
    }
    private void SetManaBar()
    {
        mana_text.text = $"{Math.Round(PlayerManager.Instance.CurrentMana)} / {Math.Round(PlayerManager.Instance.Mana)}";
        float mana_fill = PlayerManager.Instance.CurrentMana / PlayerManager.Instance.Mana;
        if (mana_fill != mana_bar.fillAmount)
        {
            mana_bar.fillAmount = mana_fill;
        }
    } 
    private void SetEaseManaBar()
    {
        if (erase_mana_bar.fillAmount != mana_bar.fillAmount)
        {
            erase_mana_bar.fillAmount = Mathf.MoveTowards(erase_mana_bar.fillAmount, mana_bar.fillAmount, lerp_speed * Time.deltaTime);
        }
    }
}
