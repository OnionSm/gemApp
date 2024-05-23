using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour
{

    public Image health_bar;
    public Image erase_health_bar;
    public float lerp_speed;
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
        this.lerp_speed = 0.8f;
        this.alive = true;
    }
    private void SetHealthBar()
    {
        float hp_fill = PlayerManager.Instance.CurrentHP / PlayerManager.Instance.Health;
        if(hp_fill != health_bar.fillAmount)
        {
            health_bar.fillAmount = hp_fill;
        }
    }
    private void SetEaseHealthBar()
    {
        if(erase_health_bar.fillAmount !=  health_bar.fillAmount)
        {
            erase_health_bar.fillAmount = Mathf.MoveTowards(erase_health_bar.fillAmount, health_bar.fillAmount, lerp_speed* Time.deltaTime);
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
}
