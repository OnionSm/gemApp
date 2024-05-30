using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetArrowPrefabs : MonoBehaviour
{
    [SerializeField] public static GetArrowPrefabs Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            GetArrowPrefabs.Instance = this;
        }
        else
        {
            Debug.Log("More than one GetArrowPrefabs");
        }
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
