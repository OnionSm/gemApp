using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : OnionBehaviour
{
    [SerializeField] private Animator animator;
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
    
    public void SetAnimation(string value)
    {
        animator.Play(value);
    }
}
