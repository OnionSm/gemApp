using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : OnionBehaviour
{
    [SerializeField] private float player_speed = 5f;
    [SerializeField] private float model_scale_x = 5f;
    [SerializeField] private float move_direction = 1f;
    [SerializeField] private PlayerAnimation animations;
    [SerializeField] private float jump_height = 8f;
    [SerializeField] private bool can_jumpping = false;
    [SerializeField] private Transform circle_jump_checking;
    [SerializeField] private LayerMask ground;
    [SerializeField] private Rigidbody2D rigid_body;
    [SerializeField] private LayerMask ceil;
    [SerializeField] private bool isDash = false;
    [SerializeField] private float dash_time = 0.767f;
    [SerializeField] private float end_dash_time;
    [SerializeField] private float dash_force = 5f;
    //[SerializeField] private bool can_jump_down = false;
 
    private void Awake()
    {
        this.animations = GetComponent<PlayerAnimation>();
        this.rigid_body = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        this.CanRunning();
        this.CanJumpping();
        this.CanJumpDown();
        this.CanDash();
        
    }
    private void FixedUpdate()
    {
        if (!isDash) return;
        
    }
    protected void Moving()
    {
        transform.position += new Vector3(this.move_direction * this.player_speed * Time.deltaTime, 0, 0);
        animations.SetBoolUseSkill(false);
        animations.SetBoolRuningAnimation(true);
    }
    protected void Jumpping()
    {
        rigid_body.velocity = Vector2.up * jump_height;
        animations.SetBoolJumpAnimation(true);
        animations.SetFloatJumpAnimation(0);
        animations.SetBoolRuningAnimation(false);
        animations.SetBoolUseSkill(false);
    }
    protected void CanRunning()
    {
        if (isDash)
        {
            return;
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.move_direction = -1;
            this.RotatePlayer(this.move_direction);
            this.Moving();
            return;
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.move_direction = 1;
            this.RotatePlayer(this.move_direction);
            this.Moving();
            return;
        }
        animations.SetBoolRuningAnimation(false);
    }
    protected void RotatePlayer(float value)
    {
        Vector3 new_scale = new Vector3(value * model_scale_x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
        gameObject.transform.localScale = new_scale;
    }

    protected void CanJumpping()
    {
        if(isDash)
        {
            return;
        }
        this.can_jumpping = Physics2D.OverlapCircle(circle_jump_checking.position, 0.1f, ground);
        if(can_jumpping)
        {
            animations.SetBoolJumpAnimation(false);
        }
        if (Input.GetKey(KeyCode.Space) && this.can_jumpping)
        {
            this.RotatePlayer(this.move_direction);
            this.Jumpping();
            return;
        }   
    }
    protected void CanJumpDown()
    {
        if(rigid_body.velocity.y <= 0 && can_jumpping == false)
        {
            Debug.Log("Down");
            animations.SetFloatJumpAnimation(1);
        }
    }
    protected void CanDash()
    { 
        if (Input.GetKey(KeyCode.T) && isDash == false)
        {
            this.isDash = true;
            this.end_dash_time = Time.time + dash_time;
            animations.SetBoolDashAnimation(true);
            return;
        }
        if (Time.time >= end_dash_time)
        {
            this.isDash = false;
            animations.SetBoolDashAnimation(false);
        }
        else if(Time.time < end_dash_time && isDash == true)
        {
            this.Dash();
        }
    }
    protected void Dash()
    {
        transform.position += new Vector3(this.move_direction * this.dash_force * Time.deltaTime, 0, 0);
    }
}


