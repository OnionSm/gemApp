using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : OnionBehaviour
{
    public float player_speed = 85f;

    private int move_direct = 0;

    [SerializeField] private bool is_ground = true;

    [SerializeField] private float jump_force = 100f;

    private bool is_jumping = false;

    private bool is_walking = false;


    [SerializeField] private float gravity_mult = 3f;
    [SerializeField] private Vector2 gravity_direct;


    [SerializeField] private PlayerAnimation animations;



    [SerializeField] private Transform circle_jump_checking;


    [SerializeField] private LayerMask ground;


    [SerializeField] private Rigidbody2D rigid_body;


    private Vector2 new_velocity;

    private void Awake()
    {
        this.animations = GetComponent<PlayerAnimation>();
        this.rigid_body = GetComponent<Rigidbody2D>();

        gravity_direct = new Vector2(0, rigid_body.gravityScale);
    }
    void Start()
    {

    }


    void Update()
    {
        this.CanMove();
        this.CheckGround();
        this.CheckFalling();
    }


    private void FixedUpdate()
    {
    }
    public void PointerDownRight()
    {
        this.move_direct = 1;
        PlayerManager.Instance.player_direction = this.move_direct;
        PlayerManager.Instance.RotatePlayer();
    }
    public void PointerDownLeft()
    {
        this.move_direct = -1;
        PlayerManager.Instance.player_direction = this.move_direct;
        PlayerManager.Instance.RotatePlayer();
    }
    public void PointerUpRight()
    {
        this.move_direct = 0;
    }
    public void PointerUpLeft()
    {
        this.move_direct = 0;
    }



    public void CanMove()
    {
        if (this.move_direct == -1 || this.move_direct == 1 )
        {
            PlayerManager.Instance.player_direction = move_direct;
            Moving();
        }
        else
        {
            animations.SetWalking(false);
            is_walking = false;
            if (is_jumping)   
                rigid_body.velocity = new Vector2(0,rigid_body.velocity.y);
            else if(is_walking == false && PlayerManager.Instance.is_dashing == false)
                rigid_body.velocity = new Vector2(0, 0);
        }

    }

    public void Moving()
    {
        Vector2 velocity;
        if (is_jumping)
        {
            velocity = new Vector2(move_direct * player_speed  , rigid_body.velocity.y);
        }
        else
        {   
            animations.SetWalking(true);
            is_walking = true;
            velocity = new Vector2(move_direct * player_speed * PlayerManager.Instance.slope_normal_perp.x, move_direct * player_speed * PlayerManager.Instance.slope_normal_perp.y);
        }
        rigid_body.velocity = velocity;

        
    }

    public void Jumping()
    {
        
        if (is_ground)  
        {
            animations.SetBoolGround(false);
            rigid_body.velocity = new Vector2(0, jump_force);
            is_jumping = true;
        }

    }

    private void CheckGround()
    {
        this.is_ground = Physics2D.OverlapCircle(circle_jump_checking.position, 5f, ground);
        animations.SetBoolGround(is_ground);
        if (rigid_body.velocity.y == 0 && is_ground)
        {
            is_jumping = false;
        }

    }
    private void CheckFalling()
    {
        if (rigid_body.velocity.y < 0 && is_jumping == true)
        {
            this.Falling();
            animations.SetFloatVelocityY(rigid_body.velocity.y);
        }
    }
    private void Falling()
    {
        rigid_body.velocity -= gravity_direct * gravity_mult * Time.deltaTime; 
    }


}