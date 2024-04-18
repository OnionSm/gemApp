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
}
