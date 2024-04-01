using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerDefend : OnionBehaviour
{
    [SerializeField] private PlayerAnimation animations;
    [SerializeField] private float block_animation_time;
    [SerializeField] private float end_block_time;

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
            this.Defend();
        if (Input.GetKeyUp(KeyCode.F))
        {
            Debug.Log("F key released!");
        }

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
