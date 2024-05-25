using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatAttack : FSMAction
{
    private EnemyCore enemyCore;
    private EnemyAnimationManager animationManager;
    private float attack_cast;
    private float cool_down_attack;
    private float attack_cast_count;
    private float cool_down_count;
    [SerializeField] private DecisionAttackPlayer decision;
    private bool is_attacking;
    private bool can_make_dame;


    private void Awake()
    {
        enemyCore = GetComponent<EnemyCore>();
        this.animationManager = GetComponentInChildren<EnemyAnimationManager>();
        this.decision = GetComponent<DecisionAttackPlayer>();
    }
    // Start is called before the first frame update
    private void Start()
    {
        this.LoadComponent();
    }
    private void Update()
    {
        this.MinusAttackCast();
        this.MinusCoolDown();
        this.CheckTakeDamage();
        this.CheckEndSkill();
    }
    public override void Action()
    {
        this.AttackPlayer();
    }
    private void AttackPlayer()
    {
        if (this.is_attacking == false && cool_down_count <= 0)
        {
            animationManager.SetAttacking(true);
            this.attack_cast_count = attack_cast;
            this.cool_down_count = cool_down_attack;
            this.is_attacking = true;
            this.can_make_dame = true;
        }
        

    }
    private void LoadComponent()
    {
        this.attack_cast = 0.55f;
        this.attack_cast_count = 0;
        this.cool_down_attack = 1f;
        this.cool_down_count = 0;
        this.is_attacking = false;
        this.can_make_dame = false;
    }
    private void MinusCoolDown()
    {
        cool_down_count -= Time.deltaTime;
    }
    private void MinusAttackCast()
    {
        attack_cast_count -= Time.deltaTime;
    }
    private void CheckTakeDamage()
    { 
        if(attack_cast_count > 0.1 & attack_cast_count < 0.25 && decision.IsAttackPlayer() && can_make_dame == true)
        {
            PlayerManager.Instance.MinusHp(50f);
            this.can_make_dame = false;
        }
    }
    private void CheckEndSkill()
    {
        if(attack_cast_count <= 0)
        {
            this.is_attacking = false;
            animationManager.SetBoolWalking(true);
        }
    }
}
