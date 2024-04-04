using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    [SerializeField] public Animator animator;

    protected void Awake()
    {
        this.LoadComponent();
    }
    public virtual void LoadComponent()
    {
        this.LoadAnimator();
    }
    public void LoadAnimator()
    {
        if (animator != null) return;
        this.animator = GetComponent<Animator>();
    }

}
