using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Despawn : OnionBehaviour
{
    protected void FixedUpdate()
    {
        this.Despawning();
    }
    protected abstract bool CanDespawn();
    protected virtual void Despawning()
    {
        if (!this.CanDespawn()) return;
        this.DespawnObject();
    }
    protected abstract void DespawnObject();
   
}
