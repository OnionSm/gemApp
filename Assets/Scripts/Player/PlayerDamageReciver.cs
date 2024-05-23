using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageReceiver : MonoBehaviour, IDamageReceiver
{
    
    public void ReceiveDamage(float value)
    {
        PlayerManager.Instance.MinusHp(value);
    }
}
