using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : Spawner
{
    [SerializeField] public static BulletSpawner Instance;

    public override void Awake()
    {
        base.Awake();
        if (BulletSpawner.Instance != null) return;
        BulletSpawner.Instance = this;
    }

}
