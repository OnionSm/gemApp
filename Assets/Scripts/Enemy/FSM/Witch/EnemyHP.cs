using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{

    public Image health_bar;
    public Image erase_health_bar;
    public float lerp_speed;

    private void Awake()
    {

    }
    public void Start()
    {
        this.LoadComponent();
    }
    public void Update()
    {
        SetHealthBar();
        SetEaseHealthBar();
        CheckMaxHp();
    }
    public  void GainHP(float value)
    {
        WitchManager.Instance.hp_current += value;

    }
    public void DecreaseHP(float value)
    {
        WitchManager.Instance.hp_current -= value;

    }
    public void LoadComponent()
    {
        this.lerp_speed = 0.8f;
    }
    public void SetHealthBar()
    {
        float hp_fill = WitchManager.Instance.hp_current / WitchManager.Instance.hp_max;
        if (hp_fill != health_bar.fillAmount)
        {
            health_bar.fillAmount = hp_fill;
        }
    }
    public void SetEaseHealthBar()
    {
        if (erase_health_bar.fillAmount != health_bar.fillAmount)
        {
            erase_health_bar.fillAmount = Mathf.MoveTowards(erase_health_bar.fillAmount, health_bar.fillAmount, lerp_speed * Time.deltaTime);
        }
    }
    public void AddHP(float value)
    {
        WitchManager.Instance.hp_current += value;
        if (WitchManager.Instance.hp_current > WitchManager.Instance.hp_max)
        {
            WitchManager.Instance.hp_current = WitchManager.Instance.hp_max;
        }
    }
    public void MinusHP(float value)
    {
        WitchManager.Instance.hp_current -= value;
        if (WitchManager.Instance.hp_current > WitchManager.Instance.hp_max)
        {
            WitchManager.Instance.hp_current = WitchManager.Instance.hp_max;
        }
    }
    private void CheckMaxHp()
    {
        if (WitchManager.Instance.hp_current > WitchManager.Instance.hp_max)
        {
            WitchManager.Instance.hp_current = WitchManager.Instance.hp_max;
        }
    }
}
