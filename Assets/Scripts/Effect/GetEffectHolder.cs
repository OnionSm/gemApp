using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetEffectHolder : MonoBehaviour
{
    [SerializeField] public static GetEffectHolder Instance;

    private void Awake()
    {
        GetEffectHolder.Instance = this;
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
