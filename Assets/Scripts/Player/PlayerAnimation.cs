using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private readonly int isRunning = Animator.StringToHash("isRunning");
    private readonly int isJumpping = Animator.StringToHash("isJumpping");
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
    protected void LoadComponent()
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
    public void SetBoolJumppingAnimation(bool value)
    {
        animator.SetBool(isJumpping, value);
    }
}
