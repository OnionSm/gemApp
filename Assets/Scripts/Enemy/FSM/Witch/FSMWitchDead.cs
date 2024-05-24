using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMWitchDead : FSMWitchBase
{
    public override void EnterState()
    {
        WitchAnimationManager.Instance.SetTriggerDeath();
    }

    public override void OnCollisionEnter()
    {
        
    }

    public override void UpdateState()
    {
       
    }
}
