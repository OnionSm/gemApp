using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMWitchIdle : FSMWitchBase
{
    [SerializeField] private float idle_time;
    [SerializeField] private float heal_cool_down;
    private void Start()
    {
        this.LoadComponent();
    }
    public override void EnterState()
    {
        Debug.Log("Enter Idle State");
    }
    public override void UpdateState()
    {
        CountIdleTime();
        CanHeal();
        ResetHealCoolDownTime();
        CanChangeChasingState();
    }
    public override void OnCollisionEnter()
    {

    }
    private void CountIdleTime()
    {
        this.idle_time += Time.deltaTime;
    }

    // Check Witch can heal when idle_state > heal_cool_down
    private void CanHeal()
    {
        if (this.idle_time >= heal_cool_down && this.CheckWitchHP())
        {
            FSMWitchManager.Instance.SwitchState(FSMWitchManager.Instance.witch_heal);
        }
    }

    // Check Witch current hp is higher than max hp
    private bool CheckWitchHP()
    {
        if (WitchManager.Instance.witch_hp_current <= WitchManager.Instance.witch_hp_max * 0.4f)
            return true;
        return true;
    }

    protected void LoadComponent()
    {
        this.idle_time = 0f;
        this.heal_cool_down = 5f;
    }
    protected void ResetHealCoolDownTime()
    {
        if(WitchManager.Instance.in_attack_zone_ball_lighting)
        {
            this.idle_time = 0f;
        }
    }
    private void CanChangeChasingState()
    {
        bool test = WitchManager.Instance.chasing == true && WitchManager.Instance.in_attack_zone_ball_lighting == false && WitchManager.Instance.in_attack_zone_water_push == false;
        Debug.Log(test);
        if(WitchManager.Instance.chasing == true && (WitchManager.Instance.in_attack_zone_ball_lighting == false && WitchManager.Instance.in_attack_zone_water_push == false))
        {
            FSMWitchManager.Instance.SwitchState(FSMWitchManager.Instance.witch_chase);
        }
    }
}
