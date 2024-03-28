using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSender : MonoBehaviour
{
    [SerializeField] private float damage = 1f;
    
    public virtual void Send(Transform obj)
    {
        DamageReceiver damage_receiver;
        damage_receiver = obj.GetComponent<DamageReceiver>();
        if (damage_receiver == null) return;
        this.SendDamage(damage_receiver);
    }
    protected virtual void SendDamage(DamageReceiver damage_receiver)
    {
        damage_receiver.DecreaseHP(this.damage);
        this.DestroyObject();
    }
    protected void DestroyObject()
    {
        Destroy(gameObject);
    }
}
