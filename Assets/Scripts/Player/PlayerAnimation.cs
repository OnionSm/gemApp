using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : OnionBehaviour
{
    [SerializeField] private Animator animator;
    private readonly int isRunning = Animator.StringToHash("isRunning");
    private readonly int isJumpUp = Animator.StringToHash("isJumpUp");
    private readonly int isJumpDown = Animator.StringToHash("isJumpDown");
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
    public void SetBoolJumpUpgAnimation(bool value)
    {
        animator.SetBool(isJumpUp, value);
    }
    public void SetBoolJumpDowngAnimation(bool value)
    {
        animator.SetBool(isJumpDown, value);
    }
}
