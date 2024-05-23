using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class EnemyHP : MonoBehaviour
{

    public Image health_bar;
    public Image erase_health_bar;
    public float lerp_speed;

    
    protected void Start()
    {
        LoadComponent();

    }
    protected void Update()
    {
        SetHealthBar();
        SetEaseHealthBar();
    }
    public abstract void GainHP(float value);
    public abstract void DecreaseHP(float value);
    public void LoadComponent()
    {
        this.lerp_speed = 0.8f;
    }
    public abstract void SetHealthBar();
  
    public void SetEaseHealthBar()
    {
        if (erase_health_bar.fillAmount != health_bar.fillAmount)
        {
            erase_health_bar.fillAmount = Mathf.MoveTowards(erase_health_bar.fillAmount, health_bar.fillAmount, lerp_speed * Time.deltaTime);
        }
    }
    public abstract void CheckDead();
}
