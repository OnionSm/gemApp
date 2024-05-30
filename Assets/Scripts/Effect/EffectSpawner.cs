using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSpawner : Spawner
{


    [SerializeField] public static EffectSpawner Instance;

    public void Awake()
    {

        if (EffectSpawner.Instance != null) return;
        EffectSpawner.Instance = this;
    }

    public override void LoadPrefabs()
    {
        if (this.prefabs.Count > 0) return;
        this.prefabs = GetArrowEffectPrefabs.Instance.GetPrefabs();
        this.HidePrefabs();
    }
}
