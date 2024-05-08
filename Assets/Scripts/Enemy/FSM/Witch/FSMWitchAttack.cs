using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMWitchAttack : FSMWitchBase
{
    
    public override void EnterState()
    {
        WitchAnimationManager.Instance.SetTriggerAttack();
    }
    public override void UpdateState()
    {

    }
    public override void OnCollisionEnter()
    {

    }
    
}
