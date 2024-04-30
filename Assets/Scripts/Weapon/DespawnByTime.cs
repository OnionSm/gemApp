using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DespawnByTime : Despawn
{
    public float time_despawn = 10f;

    protected override bool CanDespawn()
    {
       if(this.time_despawn <=0)
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
}
