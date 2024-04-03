using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerDefend : OnionBehaviour
{
    [SerializeField] private PlayerAnimation animations;
    [SerializeField] private float block_animation_time;
    [SerializeField] private float end_block_time;
    [SerializeField] private float hold_button_f_time;

    protected void Awake()
    {
        this.LoadComponent();
    }

    protected void Update()
    {
        this.CanDefend();
    }

    protected void CanDefend()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            this.Defend();
            this.hold_button_f_time = 0f;
        }
        if (Input.GetKey(KeyCode.F))
        this.hold_button_f_time += Time.deltaTime;
        if (Input.GetKeyUp(KeyCode.F))
        {
            Debug.Log("F key released!");
            this.hold_button_f_time = 0f;
            animations.SetAnimation("PlayerIdle");
        }
        if(this.hold_button_f_time > 0.9f)
            animations.SetAnimation("PlayerDefend_2");
    }

    protected void Defend()
    {
        animations.SetAnimation("PlayerDefend");

    }

    protected override void LoadComponent()
    {
        this.animations = GetComponent<PlayerAnimation>();
    }

}
