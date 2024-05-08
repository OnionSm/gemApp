using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMWitchAttack : FSMWitchBase
{
    [SerializeField] private Transform lightning_ball;
    [SerializeField] private Transform spawn_point;
    [SerializeField] private float speed;
    [SerializeField] private float animation_time;
    [SerializeField] private float delay;
    public override void EnterState()
    {
        WitchAnimationManager.Instance.SetTriggerAttack();
        LoadComponent();
    }
    public override void UpdateState()
    {
        this.CanChangeState();
           
    }
    public override void OnCollisionEnter()
    {

    }
    public void LoadComponent()
    {
        this.speed = 100f;
        this.animation_time = 1.8f;
        this.delay = 0f;
    }
    public void CreateLightningBall()
    {
        Transform obj = Instantiate(lightning_ball);
        obj.position = spawn_point.position;
        obj.GetComponent<Rigidbody>().velocity = new Vector2(WitchManager.Instance.direct * speed, 0f);
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
            this.ChangeOtherState();
        }
        else
        {
            delay += Time.deltaTime;
        }
    }

}
