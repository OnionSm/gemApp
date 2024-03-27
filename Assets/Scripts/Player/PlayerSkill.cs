using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : Player
{
    [SerializeField] private PlayerAnimation animations;
    [SerializeField] private bool can_use_skill;
    [SerializeField] private float melee_attack_time = 0.983f;
    [SerializeField] private float skill_1_time = 1.817f;
    [SerializeField] private float skill_2_time = 1.6f;
    [SerializeField] private float skill_3_time = 1.917f;
    [SerializeField] private float count_endskill_time;
    [SerializeField] private GameObject bullet_prefab;

    private void Awake()
    {
        this.animations = GetComponent<PlayerAnimation>();
        if(bullet_prefab == null)
        {
            this.bullet_prefab = GameObject.Find("BulletManaget/Prefabs/Arrow");
        }
    }
    void Start()
    {
        
    }
    void Update()
    {
        this.CanUseSkill();
    }
    private void CanUseSkill()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            this.count_endskill_time = Time.time + melee_attack_time;
            this.Normal_Attack();
            return;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            this.count_endskill_time = Time.time + skill_1_time;
            this.UseSkill_1();
            return;
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            this.count_endskill_time = Time.time + skill_2_time;
            this.UseSkill_2();
            return;
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            this.count_endskill_time = Time.time + skill_3_time;
            this.UseSkill_3();
            return;
        }
        if (Time.time >= count_endskill_time)
        {
            animations.SetBoolUseSkill(false);
        }
    }
    private void Normal_Attack()
    {

        animations.SetBoolUseSkill(true);
        animations.SetFloatSkill(0);
    }
    private void UseSkill_1()
    {
        animations.SetBoolUseSkill(true);
        animations.SetFloatSkill(0.33f);
    }
    private void UseSkill_2()
    {
        animations.SetBoolUseSkill(true);
        animations.SetFloatSkill(0.66f);
    }
    private void UseSkill_3()
    {
        animations.SetBoolUseSkill(true);
        animations.SetFloatSkill(1);
    }

    private void CheckEndSkill()
    {
        if (Time.time >= count_endskill_time)
        {
            animations.SetBoolUseSkill(false);
        }
    }

    /*private void InstantiateArrow()
    {
        GameObje
    }*/
}
