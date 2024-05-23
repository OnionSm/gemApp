using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchMana : EnemyMana
{
    public override void GainMana(float value)
    {
        WitchManager.Instance.AddMana(value);
    }
    public override void DecreaseMana(float value)
    {
        WitchManager.Instance.MinusMana(value);
    }
    public override void SetManaBar()
    {
        float mana_fill = WitchManager.Instance.CurrentMana / WitchManager.Instance.MaxMana;
        if (mana_fill != mana_bar.fillAmount)
        {
            mana_bar.fillAmount = mana_fill;
        }
    }
}
