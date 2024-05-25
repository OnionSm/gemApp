using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMWitchChase : FSMWitchBase
{
    public float witch_speed = 45f;
    public override void EnterState()
    {
        Debug.Log("Enter Chase State");
        WitchAnimationManager.Instance.SetBoolWalking(true);
    }
    public override void UpdateState()
    {
        ChangeOtherState();
        ChasePlayer();
    }
    public override void OnCollisionEnter()
    {

    }
    private void ChangeOtherState()
    {
        if(WitchManager.Instance.chasing == false)
        {
            WitchAnimationManager.Instance.SetBoolWalking(false);
            FSMWitchManager.Instance.SwitchState(FSMWitchManager.Instance.witch_idle);
        }
        if (WitchManager.Instance.in_attack_zone_ball_lighting == true && WitchManager.Instance.in_attack_zone_water_push == false)
        {
            FSMWitchManager.Instance.SwitchState(FSMWitchManager.Instance.witch_attack);
        }
        if(WitchManager.Instance.in_attack_zone_water_push == true)
        {
            FSMWitchManager.Instance.SwitchState(FSMWitchManager.Instance.witch_attack_fast);
        }
    }
    private void ChasePlayer()
    {

        FSMWitchManager.Instance.myrigidbody.velocity = new Vector2(WitchManager.Instance.GetDirect() * witch_speed, FSMWitchManager.Instance.myrigidbody.velocity.y);  
    }
}
