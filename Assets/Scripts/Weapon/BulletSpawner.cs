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
    public override void LoadPrefabs()
    {
        if (this.prefabs.Count > 0) return;
        this.prefabs = GetArrowPrefabs.Instance.GetPrefabs();
        this.HidePrefabs();
    }


}
