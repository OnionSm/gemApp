using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchHp : EnemyHP, IDamageable
{
    public override void GainHP(float value)
    {
        WitchManager.Instance.AddHp(value);
    }
    public override void DecreaseHP(float value)
    {
        WitchManager.Instance.MinusHp(value);
    }
    public override void SetHealthBar()
    {
        float hp_fill = WitchManager.Instance.CurrentHp / WitchManager.Instance.MaxHP;
        if (hp_fill != health_bar.fillAmount)
        {
            health_bar.fillAmount = hp_fill;
        }
    }

    public void TakeDamage(float amount)
    {
        WitchManager.Instance.MinusHp(amount);
        Debug.Log(amount);
    }

    public override void CheckDead()
    {
        if(WitchManager.Instance.CurrentHp <= 0)
        {
            
        }
    }
}
