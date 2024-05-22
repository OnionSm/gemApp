using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMWitchHeal : FSMWitchBase
{
    private float recover_amoount;
    public bool healwave_available;
    public float animation_time;
    public float delay;
    public float heal_hp_mult;
    private void Start()
    {
        
    }
    public override void EnterState()      
    {
        WitchAnimationManager.Instance.SetTriggerAttack();
        LoadComponent();
    }
    public override void UpdateState()
    {
        CanChangeState();
        CanCreateHealWave();
    }
    public override void OnCollisionEnter()
    {

    }
    private void LoadComponent()
    {
        heal_hp_mult = 0.2f;
        recover_amoount = heal_hp_mult * WitchManager.Instance.hp_max;
        animation_time = 1.8f;
        delay = 0f;
        healwave_available = true;
    }

    private void ChangeOtherState()
    {

        WitchAnimationManager.Instance.SetBoolWalking(false);
        FSMWitchManager.Instance.SwitchState(FSMWitchManager.Instance.witch_idle);


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
    private void CanCreateHealWave()
    {
        if (delay >= 1.2f && healwave_available == true)
        {
            healwave_available = false;
            WitchManager.Instance.hp_current += recover_amoount;
            CreateHealWave();
        }
    }
    public void CreateHealWave()
    {
        Transform obj = Instantiate(FSMWitchManager.Instance.heal_wave_prefabs);
        obj.gameObject.SetActive(true);
        obj.position = transform.position;
    }
}
