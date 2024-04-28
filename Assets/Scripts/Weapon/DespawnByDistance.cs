using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByDistance : Despawn
{
    [SerializeField] private float max_distance = 1000f;
    [SerializeField] private float distance = 0f;
    [SerializeField] protected Transform main_cam;

    protected override bool CanDespawn()
    {
        this.distance = Vector3.Distance(transform.position, main_cam.position);
        if (distance >= max_distance)
            return true;
        return false;
    }
}
