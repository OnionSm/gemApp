using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : Player
{
    [SerializeField] private PlayerAnimation animations;
    private void Awake()
    {
        this.animations = GetComponent<PlayerAnimation>();
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
            Debug.Log("OK");
            this.Normal_Attack();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            this.UseSkill_1();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            this.UseSkill_2();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            this.UseSkill_3();
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

}
