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

    protected override void LoadPrefabs()
    {
        if (this.prefabs.Count > 0) return;
        this.prefabs = GetArrowEffectPrefabs.Instance.GetPrefabs();
        foreach (Transform pre in this.prefabs)
        {
            Debug.Log(pre);
        }
        this.HidePrefabs();
    }
    protected override void LoadHolder()
    {
        if (this.holder != null) return;
        this.holder = GetEffectHolder.Instance.getHoder();
    }
}
