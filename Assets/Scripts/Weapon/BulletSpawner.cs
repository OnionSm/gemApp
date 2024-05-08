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
    protected override void LoadPrefabs()
    {
        if (this.prefabs.Count > 0) return;
        this.prefabs = GetArrowPrefabs.Instance.GetPrefabs();
        this.HidePrefabs();
    }

    protected override void LoadHolder()
    {
        if (this.holder != null) return;
        this.holder = GetHolder.Instance.getHoder();
    }

}
