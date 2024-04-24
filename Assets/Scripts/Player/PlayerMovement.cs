using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : OnionBehaviour
{
    public float player_speed = 8500f;

    private int move_direct = 0;

    [SerializeField] private bool is_ground = true;

    [SerializeField] private float jump_force = 10f;


    [SerializeField] private PlayerAnimation animations;



    [SerializeField] private Transform circle_jump_checking;


    [SerializeField] private LayerMask ground;


    [SerializeField] private Rigidbody2D rigid_body;


    [SerializeField] private LayerMask ceil;



    [SerializeField] private float dash_time = 0.767f;



    private Vector2 new_velocity;

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
        this.CanMove();
        this.CheckGround();
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
        if (this.move_direct == -1 || this.move_direct == 1)
        {
            // Animations
            animations.SetWalking(true);
            PlayerManager.Instance.player_direction = move_direct;
            Moving();
        }
        else
        {
            animations.SetWalking(false);
            rigid_body.velocity = new Vector2(0,rigid_body.velocity.y);
            return;
        }

    }
    public void Moving()
    {

     
        Vector2 velocity = new Vector2(move_direct * player_speed * PlayerManager.Instance.slope_normal_perp.x,move_direct * player_speed * PlayerManager.Instance.slope_normal_perp.y);
        rigid_body.velocity = velocity;
        
    }

    public void Jumping()
    {
        animations.SetBoolGround(false);
        if (is_ground)
        {
            rigid_body.velocity = new Vector2(0, 100);
        }
    }

    private void CheckGround()
    {
        this.is_ground = Physics2D.OverlapCircle(circle_jump_checking.position, 0.1f, ground);
        animations.SetBoolGround(is_ground);

    }

}