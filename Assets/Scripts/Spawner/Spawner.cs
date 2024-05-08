using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawner : OnionBehaviour
{
    [SerializeField] protected Transform holder;
    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] protected List<Transform> poolObject = new List<Transform>();
    public virtual void Start()
    {
        this.LoadComponent();
    }
    protected override void LoadComponent()
    {
        this.LoadPrefabs();
        this.LoadHolder();
    }

    protected virtual void LoadPrefabs()
    {
    }

    protected virtual void LoadHolder()
    {
    }


    protected void HidePrefabs()
    {
        foreach (Transform prefab in this.prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }

    public virtual Transform Spawn(string prefab_name, Vector3 spawn_pos, Vector3 scale)
    {
        Transform prefab = this.GetPrefabByName(prefab_name);
        if (prefab == null)
        {
            return null;
        }
        Transform new_prefab = this.GetObjectFromPool(prefab);
        SetPositionAndScale(new_prefab, spawn_pos, scale);
        new_prefab.parent = this.holder;
        return new_prefab;
    }
    protected virtual Transform GetObjectFromPool(Transform prefab)
    {
        foreach (Transform poolObj in this.poolObject)  
        {
            // bug bug bug bug bug bug bug, not bug if if (poolObj.name == prefab.name)
            if (poolObj.name == prefab.name)
            {
                this.poolObject.Remove(poolObj);
                return poolObj;
            }
        }
        Transform new_prefab = Instantiate(prefab);
        new_prefab.name = prefab.name;
        Debug.Log(transform.name + ": Clone new Obj", transform.gameObject);
        new_prefab.gameObject.SetActive(true);
        return new_prefab;
    }

    public virtual void Despawn(Transform obj)
    {
        this.poolObject.Add(obj);
        obj.gameObject.SetActive(false);
    }


    public virtual Transform GetPrefabByName(string prefab_name)
    {
        foreach (Transform prefab in this.prefabs)
        {
            if (prefab.name == prefab_name) return prefab;
        }
        return null;
    }
    protected virtual void SetPositionAndScale(Transform new_prefab, Vector3 position, Vector3 scale)
    {
        new_prefab.position = position;
        new_prefab.localScale = scale;
    }
}
