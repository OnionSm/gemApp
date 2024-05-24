using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMana : MonoBehaviour
{
    public Image mana_bar;
    public Image erase_mana_bar;
    public float lerp_speed;

    public void Awake()
    {

    }
    public void Start()
    {
        this.LoadComponent();
    }
    public void Update()
    {
        SetManaBar();
        SetEaseManaBar();
    }
    public virtual void GainMana(float value)
    {
        
    }
    public virtual void DecreaseMana(float value)
    {
        
    }
    public void LoadComponent()
    {
        this.lerp_speed = 1f;
    }
    public virtual void SetManaBar()
    {
        
    }
    public void SetEaseManaBar()
    {
        if (erase_mana_bar.fillAmount != mana_bar.fillAmount)
        {
            erase_mana_bar.fillAmount = Mathf.MoveTowards(erase_mana_bar.fillAmount, mana_bar.fillAmount, lerp_speed * Time.deltaTime);
        }
    }
    
}
