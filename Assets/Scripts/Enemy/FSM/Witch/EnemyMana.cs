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
        CheckMaxMana();
    }
    public void GainMana()
    {
        WitchManager.Instance.curent_mana += 5f;
    }
    public void DecreaseMana(float value)
    {
        WitchManager.Instance.max_mana -= value;

    }
    public void LoadComponent()
    {
        this.lerp_speed = 1f;
    }
    public void SetManaBar()
    {
        float mana_fill = WitchManager.Instance.curent_mana / WitchManager.Instance.max_mana;
        if (mana_fill != mana_bar.fillAmount)
        {
            mana_bar.fillAmount = mana_fill;
        }
    }
    public void SetEaseManaBar()
    {
        if (erase_mana_bar.fillAmount != mana_bar.fillAmount)
        {
            erase_mana_bar.fillAmount = Mathf.MoveTowards(erase_mana_bar.fillAmount, mana_bar.fillAmount, lerp_speed * Time.deltaTime);
        }
    }
    public void CheckMaxMana()
    {
        if (WitchManager.Instance.curent_mana > WitchManager.Instance.max_mana)
        {
            WitchManager.Instance.curent_mana = WitchManager.Instance.max_mana;
        }
    }

}
