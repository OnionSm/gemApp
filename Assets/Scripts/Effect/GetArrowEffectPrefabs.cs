using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetArrowEffectPrefabs : MonoBehaviour
{
    [SerializeField] public static GetArrowEffectPrefabs Instance;
    private void Awake()
    {
        GetArrowEffectPrefabs.Instance = this;
    }
    void Start()
    {
        this.GetPrefabs();
    }


    void Update()
    {

    }
    public List<Transform> GetPrefabs()
    {
        List<Transform> list_prefabs = new List<Transform>();
        foreach (Transform child in this.transform)
        {
            list_prefabs.Add(child);
        }
        return list_prefabs;
    }
}
