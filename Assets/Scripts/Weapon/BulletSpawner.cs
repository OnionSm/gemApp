using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : Spawner
{
    [SerializeField] public static BulletSpawner Instance;

    public void Awake()
    {
        
        if (BulletSpawner.Instance != null) return;
        BulletSpawner.Instance = this;
    }


}
