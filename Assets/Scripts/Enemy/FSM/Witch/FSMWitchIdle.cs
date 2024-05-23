using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMWitchIdle : FSMWitchBase
{
    [SerializeField] private float idle_time;
    [SerializeField] private float heal_cool_down;
    public override void EnterState()
    {
        Debug.Log("Enter Idle State");
        LoadComponent();
    }
    public override void UpdateState()
    {
        CountIdleTime();
        CanHeal();
        ResetHealCoolDownTime();
        CanChangeState();
    }
    public override void OnCollisionEnter()
    {

    }
    private void CountIdleTime()
    {
        idle_time += Time.deltaTime;
    }

    // Check Witch can heal when idle_state > heal_cool_down
    private void CanHeal()
    {
        if (idle_time >= heal_cool_down && this.CheckWitchHP())
        {
            Healing();
        }
    }

    // Check Witch current hp is higher than max hp
    private bool CheckWitchHP()
    {
        if (WitchManager.Instance.CurrentHp <= WitchManager.Instance.MaxHP * 0.4f)
            return true;
        return false;
    }

    protected void LoadComponent()
    {
        idle_time = 0f;
        heal_cool_down = 5f;
        WitchManager.Instance.cool_down_count = WitchManager.Instance.cool_down_time_skill;
    }
    protected void ResetHealCoolDownTime()
    {
        if(WitchManager.Instance.in_attack_zone_ball_lighting)
        {
            idle_time = 0f;
        }
    }
    
    private void ChangeOtherState()
    {
        if (WitchManager.Instance.chasing == true && (WitchManager.Instance.in_attack_zone_ball_lighting == false && WitchManager.Instance.in_attack_zone_water_push == false))
        {
            FSMWitchManager.Instance.SwitchState(FSMWitchManager.Instance.witch_chase);
        }
        if (WitchManager.Instance.in_attack_zone_ball_lighting == true && WitchManager.Instance.in_attack_zone_water_push == false)
        {
            FSMWitchManager.Instance.SwitchState(FSMWitchManager.Instance.witch_attack);
        }
        if (WitchManager.Instance.in_attack_zone_water_push == true)
        {
            FSMWitchManager.Instance.SwitchState(FSMWitchManager.Instance.witch_attack_fast);
        }
    }
    private void CanChangeState()
    {
        if(WitchManager.Instance.cool_down_count > 0)
        {
            return;
        }
        else
        {
            ChangeOtherState();
        }
    }

    private void Healing()
    {
        FSMWitchManager.Instance.SwitchState(FSMWitchManager.Instance.witch_heal);
    }
}
