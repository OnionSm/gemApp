using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMWitchHeal : FSMWitchBase
{
    [SerializeField] private float recover_amoount;
    private void Start()
    {
        this.LoadComponent();
    }
    public override void EnterState()
    {

    }
    public override void UpdateState()
    {

    }
    public override void OnCollisionEnter()
    {

    }
    private void LoadComponent()
    {
        this.recover_amoount = 100f;
    }
}
