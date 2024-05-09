using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLightningDespawnByTime : Despawn
{
    public float time_despawn = 2.5f;

    protected override bool CanDespawn()
    {
        if (this.time_despawn <= 0)
        {
            this.time_despawn = 10f;
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
        BulletSpawner.Instance.Despawn(gameObject.transform);
    }
}
