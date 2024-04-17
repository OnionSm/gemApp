using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : PlayerManager
{
    [SerializeField] private PlayerAnimation animations;
    [SerializeField] private bool can_use_skill;
    [SerializeField] private float melee_attack_time = 0.983f;
    [SerializeField] private float skill_1_time = 1.817f;
    [SerializeField] private float skill_2_time = 1.6f;
    [SerializeField] private float skill_3_time = 1.917f;
    [SerializeField] private float count_endskill_time;
    [SerializeField] private string prefab_name = "Arrow";
    [SerializeField] private bool use_skill_1 = false;
    [SerializeField] private bool use_skill = false;

    private void Awake()
    {
        this.animations = GetComponent<PlayerAnimation>();
       /* if(bullet_prefab == null)
        {
            this.bullet_prefab = GameObject.Find("BulletManaget/Prefabs/Arrow");
        }*/
    }

    void Start()
    {
        
    }
/*    void Update()
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
        this.CheckEndSkill();
        this.CreateArrow();
    }


    private void Normal_Attack()
    {
        PlayerManager.Instance.is_using_skill = true;
        animations.SetAnimation("Attack_1");
    }
    private void UseSkill_1()
    {
        this.use_skill_1 = true;
        PlayerManager.Instance.is_using_skill = true;
        animations.SetAnimation("Attack_2");
    }
    private void UseSkill_2()
    {
        this.use_skill = true;
        PlayerManager.Instance.is_using_skill = true;
        animations.SetAnimation("Attack_3");
    }   
    private void UseSkill_3()
    {
        this.use_skill = true;
        PlayerManager.Instance.is_using_skill = true;
        animations.SetAnimation("Attack_SP");
    }


    private void CheckEndSkill()
    {
        if (Time.time >= count_endskill_time && PlayerManager.Instance.is_using_skill) 
        {
            animations.SetAnimation("PlayerIdle");
            this.use_skill = false;
        }
    }

    private void CreateArrow()
    {
        if (use_skill_1 && Time.time >= count_endskill_time - 0.7)
        {
            this.use_skill_1 = false;
            Vector3 spawn_position = new Vector3(transform.position.x + 1.7f, transform.position.y - 1.2f, 0f);
            Vector3 scale = new Vector3(PlayerManager.Instance.player_direction, 1, 1);
            Transform bullet = BulletSpawner.Instance.Spawn(prefab_name, spawn_position, scale);
            if(bullet.gameObject.activeSelf) return;
            bullet.gameObject.SetActive(true);
        }
    }*/
}
