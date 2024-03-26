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
    [SerializeField] private float jump_height = 6f;
    [SerializeField] private bool can_jumpping = false;
    [SerializeField] private Transform circle_jump_checking;
    [SerializeField] private LayerMask ground;
    [SerializeField] private Rigidbody2D rigid_body;
    [SerializeField] private LayerMask ceil;
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
       //this.CanJumpDown();
    }
    protected void Moving()
    {
        transform.position += new Vector3(this.move_direction * this.player_speed * Time.deltaTime, 0, 0);
        animations.SetBoolUseSkill(false);
        animations.SetBoolRuningAnimation(true);
    }
    protected void Jumpping()
    {
        rigid_body.velocity = new Vector2(rigid_body.velocity.x, jump_height);
        animations.SetBoolJumpAnimation(true);
        animations.SetFloatJumpAnimation(0);
        animations.SetBoolRuningAnimation(false);
        animations.SetBoolUseSkill(false);
    }
    protected void CanRunning()
    {
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
   /* protected void CanJumpDown()
    {
        this.can_jump_down = Physics2D.OverlapCircle(circle_jump_checking.position, 0.1f, ceil);
        Debug.Log(can_jump_down);
        if (!can_jump_down) return;
        animations.SetFloatJumpAnimation(1);
    }*/
}


