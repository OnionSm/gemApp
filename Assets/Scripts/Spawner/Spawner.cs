using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : OnionBehaviour
{
    [SerializeField] private Transform holder;
    [SerializeField] private List<Transform> prefabs;
    [SerializeField] private List<Transform> poolObject;

    protected override void LoadComponent()
    {
        this.LoadPrefabs();
        this.LoadHolder();
    }

    protected void LoadPrefabs()
    {
        if (this.prefabs.Count > 0) return;
        Transform prefabObject = transform.Find("Prefabs");
        foreach(Transform prefab in prefabObject)
        {
            this.prefabs.Add(prefab);
        }
        this.HidePrefabs();
    }

    protected void LoadHolder()
    {
        if (this.holder != null) return;
        this.holder = transform.Find("Holder");
    }

    protected void HidePrefabs()
    {
        foreach (Transform prefab in this.prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }

    public virtual Transform Spawn(string prefab_name, Vector3 spawn_pos, Quaternion rotation)
    {
        Transform prefab = this.GetPrefabByName(prefab_name);
        if(prefab == null)
        {
            return null;
        }
        Transform new_prefab = this.GetObjectFromPool(prefab);
        new_prefab.SetPositionAndRotation(spawn_pos, rotation);
        new_prefab.parent = this.holder;
        return new_prefab;
    }
    protected void GetObjectFromPool(Transform prefab)
    {
        foreach(Transform poolObj in this.poolObject)
        {
            if(poolObj.name == prefab.name)
            {
                this.poolObject.Remove(poolObj);
                return poolObj;
            }
        }
        Transform new_prefab = Instantiate(prefab);
        new_prefab.name = prefab.name;
        return new_prefab;
    }
    public virtual void Despawn(Transform obj)
    {
        this.poolObject.Add(obj);
        obj.gameObject.SetActive(false);
    }

    public virtual Transform GetPrefabByName(string prefab_name)
    {
        foreach(Transform prefab in this.prefabs)
        {
            if (prefab.name == prefab_name) return prefab;
        }
    }
}
