using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationManager : MonoBehaviour
{

    [SerializeField] private Animator animator;

    private readonly int is_walking = Animator.StringToHash("IsWalking");
    private readonly int attacking  = Animator.StringToHash("Attacking");
    private readonly int death = Animator.StringToHash("Death");
    private void Awake()
    {
       
    }

    // Start is called before the first frame update
    
    public void SetBoolWalking(bool value)
    {
        animator.SetBool(is_walking, value);
    }
    public void SetAttacking(bool value)
    {
        animator.SetBool(attacking, value);
    }
    public void SetDeathTrigger() 
    {
        animator.SetTrigger(death);
    }
}
