using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDespawnByTime : Despawn
{
    public float time_despawn = 2f;

    protected override bool CanDespawn()
    {
        if (this.time_despawn <= 0)
        {
            this.time_despawn = 2f;
            return true;
        }
        else
        {
            time_despawn -= Time.fixedDeltaTime;
            return false;
        }
    }
    protected override void DespawnObject()
    {
        //BulletSpawner.Instance.Despawn(gameObject.transform);
    }
}
