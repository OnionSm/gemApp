using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour, IDamageable
{
    public bool alive;

    private void Awake()
    {
        
    }
    private void Start()
    {
        this.LoadComponent();
    }
    public void Update()
    {
        SetHealthBar();
        SetEaseHealthBar();
        DeadCheck();
    }
    public void GainHP(float value)
    {
        PlayerManager.Instance.AddHp(value);
      
    }
    public void DecreaseHP(float value)
    {
        PlayerManager.Instance.MinusHp(value);
        
    }
    private void LoadComponent()
    {
        this.alive = true;
    }
    private void SetHealthBar()
    {
        PlayerUIManager.Instance.health_text.text = $"{Math.Round(PlayerManager.Instance.CurrentHP)} / {Math.Round(PlayerManager.Instance.Health)}";
        float hp_fill = PlayerManager.Instance.CurrentHP / PlayerManager.Instance.Health;
        if(hp_fill != PlayerUIManager.Instance.health_bar.fillAmount)
        {
            PlayerUIManager.Instance.health_bar.fillAmount = hp_fill;
        }
    }
    private void SetEaseHealthBar()
    {
        if(PlayerUIManager.Instance.erase_health_bar.fillAmount != PlayerUIManager.Instance.health_bar.fillAmount)
        {
            PlayerUIManager.Instance.erase_health_bar.fillAmount = Mathf.MoveTowards(PlayerUIManager.Instance.erase_health_bar.fillAmount, PlayerUIManager.Instance.health_bar.fillAmount, PlayerUIManager.Instance.LerpSpeed * Time.deltaTime);
        }
    }
    private void DeadCheck()
    {
        if(PlayerManager.Instance.CurrentHP <= 0 && alive)
        {
            PlayerAnimation.Instance.SetTriggerDeath();
            alive = false;
        }
    }

    public void TakeDamage(float amount)
    {
        PlayerManager.Instance.MinusHp(amount);
    }
}
