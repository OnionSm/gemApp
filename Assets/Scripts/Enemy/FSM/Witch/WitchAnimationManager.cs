using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchAnimationManager : MonoBehaviour
{
    public static WitchAnimationManager Instance;
    [SerializeField] private Animator animator;


    private readonly int is_walking = Animator.StringToHash("IsWalking");
    private readonly int ground = Animator.StringToHash("Ground");
    private readonly int is_attack = Animator.StringToHash("Attacking");
    private readonly int attack_speed = Animator.StringToHash("AttackSpeed");
    private readonly int is_death = Animator.StringToHash("Death");
    private readonly int is_attack_fast = Animator.StringToHash("AttackFast");

    private void Awake()
    {
        WitchAnimationManager.Instance = this;
       
    }
    void Start()
    {
        this.LoadComponent();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected void LoadAnimator()
    {
        if (animator != null) return;
        this.animator = GetComponent<Animator>();
    }
    public void SetBoolWalking(bool value)
    {
        animator.SetBool(is_walking, value);
    }
    public void SetBoolGround(bool value)
    {
        animator.SetBool(ground, value);
    }
    public void SetTriggerAttack()
    {
        animator.SetTrigger(is_attack);
    }
    public void SetFloatAttackSpeed(float value)
    {
        animator.SetFloat(attack_speed, value);
    }
    public void SetTriggerDeath()
    {
        animator.SetTrigger(is_death);
    }
    public void SetTriggerAttackFast()
    {
        animator.SetTrigger(is_attack_fast);
    }
    protected void LoadComponent()
    {
        animator = GetComponent<Animator>();
    }
}
