using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : OnionBehaviour
{
   /* [SerializeField] private Animator animator;
    private readonly int is_walking = Animator.StringToHash("IsWalking");
    private readonly int ground = Animator.StringToHash("Ground");
    private readonly int attack_speed = Animator.StringToHash("AttackSpeed");
    private readonly int move_speed  = Animator.StringToHash("MoveSpeed");
    private readonly int idle_speed = Animator.StringToHash("IdleSpeed");
    private readonly int base_strike_0 = Animator.StringToHash("BaseStrike0");
    private readonly int death = Animator.StringToHash("Death");
    private readonly int revive = Animator.StringToHash("Revive");
    private readonly int velocity_y = Animator.StringToHash("VelocityY");
    private readonly int ground_slam_hit = Animator.StringToHash("GroundSlamHit");
    private readonly int ground_slam_air = Animator.StringToHash("GroundSlamAir");
    private readonly int base_shot = Animator.StringToHash("BaseShot");
    private readonly int barrage = Animator.StringToHash("Barrage");
    private readonly int resurrect = Animator.StringToHash("Resurrect");
    private readonly int special_shot = Animator.StringToHash("SpecialShot");
    private readonly int angle_shot = Animator.StringToHash("AngleShot");


    private void Awake()
    {
        this.LoadComponent();
    }
    void Start()
    {   
       
    }

    void Update()
    {
        
    }
    
    protected override void LoadComponent()
    {
        this.LoadAnimator();
    }
    protected void LoadAnimator()
    {
        if (animator != null) return;
        this.animator = GetComponent<Animator>();
    }
    
    public void SetWalking(bool value)
    {
        animator.SetBool(is_walking, value);
    }
    public void SetBoolGround(bool value)
    {
        animator.SetBool(ground, value);
    }
    public void SetAttackSpeed(float value)
    {
        animator.SetFloat(attack_speed, value);
    }
    public void SetMoveSpeed(float value)
    {
        animator.SetFloat(move_speed, value);
    }
    public void SetIdleSpeed(float value)
    {
        animator.SetFloat(idle_speed, value);
    }
    public void SetTriggerBaseStrike0()
    {
        animator.SetTrigger(base_strike_0);
    }
    public void SetTriggerDeath()
    {
        animator.SetTrigger(death);
    }
    public void SetTriggerRevive()
    {
        animator.SetTrigger(revive);
    }
    public void SetFloatVelocityY(float value)
    {
        animator.SetFloat(velocity_y, value);
    }
    public void SetTriggerGroundSlamHit()
    {
        animator.SetTrigger(ground_slam_hit);
    }
    public void SetTriggerGroundSlamAir()
    {
        animator.SetTrigger(ground_slam_air);
    }
    public void SetTriggerBaseShot()
    {
        animator.SetTrigger(base_shot);
    }
    public void SetTriggerBarrage()
    {
        animator.SetTrigger(barrage);
    }
    public void SetTriggerResurrect()
    {
        animator.SetTrigger(resurrect);
    }
    public void SetTriggerSpecialShot()
    {
        animator.SetTrigger(special_shot);
    }
    public void SetTriggerAngleShot()
    {
        animator.SetTrigger(angle_shot);
    }*/
}
