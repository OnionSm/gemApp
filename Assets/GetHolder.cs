using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHolder : MonoBehaviour
{
    [SerializeField] public static GetHolder Instance;

    private void Awake()
    {
        GetHolder.Instance = this;
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }   

    public Transform getHoder()
    {
        return this.transform;
    }
}
