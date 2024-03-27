using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : OnionBehaviour
{
    [SerializeField] private Animator animator;
    private readonly int isRunning = Animator.StringToHash("isRunning");
    private readonly int isJump = Animator.StringToHash("isJump");
    private readonly int Jump = Animator.StringToHash("Jump");
    private readonly int UseSkill = Animator.StringToHash("useSkill");
    private readonly int Skill = Animator.StringToHash("Skill");
    private readonly int isDash = Animator.StringToHash("isDash");

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
    public void SetBoolRuningAnimation(bool value)
    {
        animator.SetBool(isRunning, value);
    }
    public void SetBoolJumpAnimation(bool value)
    {
        animator.SetBool(isJump, value);
    }
    public void SetFloatJumpAnimation(float value)
    {
        animator.SetFloat(Jump, value);
    }

    public void SetBoolUseSkill(bool value)
    {
        animator.SetBool(UseSkill, value);
    }

    public void SetFloatSkill(float value)
    {
        animator.SetFloat(Skill, value);
    }
    public void SetBoolDashAnimation(bool value)
    {
        animator.SetBool(isDash, value);
    }
}
