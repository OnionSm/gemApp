using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : OnionBehaviour
{
    public float player_speed = 85f;

    private int move_direct = 0;

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
    [SerializeField] private bool can_jump_down = false;

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

    }
    private void FixedUpdate()
    {
        //if (!isDash) return;

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
            Moving();
        }
        else
        {
            animations.SetWalking(false);
            rigid_body.velocity = Vector2.zero;
            return;
        }

    }
    public void Moving()
    {
        new_velocity.Set(move_direct * this.player_speed * PlayerManager.Instance.slope_normal_perp.x, move_direct * this.player_speed * PlayerManager.Instance.slope_normal_perp.y);
        rigid_body.velocity = new_velocity;
        transform.position += new Vector3(move_direct * this.player_speed * PlayerManager.Instance.slope_normal_perp.x * Time.deltaTime, move_direct * this.player_speed * PlayerManager.Instance.slope_normal_perp.y * Time.deltaTime, 0);
        PlayerManager.Instance.player_direction = move_direct;
    }


}