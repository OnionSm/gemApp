using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMWitchAttack : FSMWitchBase
{
    public float speed;
    public float animation_time;
    public float delay;
    public bool ball_available;
    public override void EnterState()
    {
        WitchAnimationManager.Instance.SetTriggerAttack();
        LoadComponent();
    }
    public override void UpdateState()
    {
        CanChangeState();
        CanCreateLightningBall();


    }
    public override void OnCollisionEnter()
    {

    }
    public void LoadComponent()
    {
        this.speed = 100f;
        this.animation_time = 1.8f;
        this.delay = 0f;
        this.ball_available = true;
    }
    public void CreateLightningBall()
    {
        Transform obj = Instantiate(FSMWitchManager.Instance.ball_lightning_prefabs);
        obj.gameObject.SetActive(true);
        obj.gameObject.GetComponent<BallLightningMove>().SetDamage(WitchManager.Instance.my_config.damage);
        obj.position = FSMWitchManager.Instance.spawn_point.position; 

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
    private void CanCreateLightningBall()
    {
        if(delay>=1.2f && ball_available == true)
        {
            this.ball_available = false;
            CreateLightningBall();
        }
    }

}
