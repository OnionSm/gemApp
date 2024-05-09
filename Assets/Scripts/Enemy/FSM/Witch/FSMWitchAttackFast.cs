using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMWitchAttackFast : FSMWitchBase
{
    [SerializeField] private float animation_time;
    [SerializeField] private float delay;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void EnterState()
    {
        WitchAnimationManager.Instance.SetTriggerAttackFast();
        this.LoadComponent();
        WitchManager.Instance.cool_down_count = WitchManager.Instance.cool_down_time_skill;
    }
    public override void UpdateState()
    {
        ChangeOtherState();
    }
    public override void OnCollisionEnter()
    {

    }
    private void ChangeOtherState()
    {
        if (WitchManager.Instance.chasing == false)
        {
            WitchAnimationManager.Instance.SetBoolWalking(false);
            FSMWitchManager.Instance.SwitchState(FSMWitchManager.Instance.witch_idle);
        }
        if (WitchManager.Instance.chasing == true && (WitchManager.Instance.in_attack_zone_ball_lighting == false && WitchManager.Instance.in_attack_zone_water_push == false))
        {
            FSMWitchManager.Instance.SwitchState(FSMWitchManager.Instance.witch_chase);
        }
        if (WitchManager.Instance.in_attack_zone_ball_lighting == true)
        {
            FSMWitchManager.Instance.SwitchState(FSMWitchManager.Instance.witch_attack);
        }
        

    }
    private void CanChangeState()
    {
        if (delay >= animation_time)
        {
            ChangeOtherState();
        }
        else
        {
            delay += Time.deltaTime;
        }
    }
    public void LoadComponent()
    {
        animation_time = 1.8f;
        delay = 0f;
    }
}
