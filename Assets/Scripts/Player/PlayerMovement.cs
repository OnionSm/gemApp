using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : OnionBehaviour
{
    [SerializeField] private float player_speed = 5f;

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
        if(this.move_direct == -1 || this.move_direct == 1)
        {
            // Animations
            Moving();
        }
        else
        {

            // Animations
            return;
        }

    }
    public void Moving()
    {
        transform.position += new Vector3(move_direct  * this.player_speed*20 * Time.deltaTime, 0, 0);
        animations.SetWalking(true);
        //PlayerManager.Instance.player_direction = value;
    }

    
   /* protected void Jumpping()
    {
        rigid_body.velocity = Vector2.up * jump_height;
    }


    protected void CanRunning()
    {
        if (Dashing()) return;
        if (Input.GetKey(KeyCode.A))
        {
            PlayerManager.Instance.player_direction = -1;
            this.RotatePlayer(PlayerManager.Instance.player_direction);
            ChangeAnimationState("PlayerRun");
            PlayerManager.Instance.is_using_skill = false;
            this.Moving();
            return;
        }
        if (Input.GetKey(KeyCode.D))    
        {
            PlayerManager.Instance.player_direction = 1;
            this.RotatePlayer(PlayerManager.Instance.player_direction);
            ChangeAnimationState("PlayerRun");
            PlayerManager.Instance.is_using_skill = false;
            this.Moving();
            return;
        }
        if(PlayerManager.Instance.current_animation == "PlayerRun")
            ChangeAnimationState("PlayerIdle");
    }
    protected void RotatePlayer(float value)
    {
        Vector3 new_scale = new Vector3(value * PlayerManager.Instance.model_scale_x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
        gameObject.transform.localScale = new_scale;
    }

    protected void CanJumpping()
    {
        if (Dashing()) return;
        this.can_jumpping = Physics2D.OverlapCircle(circle_jump_checking.position, 0.1f, ground);
        if (PlayerManager.Instance.current_animation == "PlayerJumpDown" && this.can_jumpping)
        {
            ChangeAnimationState("PlayerIdle");
        }
        if (Input.GetKey(KeyCode.Space) && this.can_jumpping)
        {
            this.RotatePlayer(PlayerManager.Instance.player_direction);
            this.can_jump_down = true;
            ChangeAnimationState("PlayerJumpUp");
            PlayerManager.Instance.is_using_skill = false;
            this.Jumpping();
            return;
        }   
    }
    protected void CanJumpDown()
    {
        if (rigid_body.velocity.y <= 0 && this.can_jump_down)
        {
            Debug.Log("Down");
            this.can_jump_down = false;
            ChangeAnimationState("PlayerJumpDown");
        }
    }
    protected void CanDash()
    { 
        if (Input.GetKey(KeyCode.T) && !this.Dashing())
        {
            this.isDash = true;
            this.end_dash_time = Time.time + dash_time;
            PlayerManager.Instance.is_using_skill = false;
            ChangeAnimationState("PlayerDash");
            return;
        }
        if (Time.time >= end_dash_time && this.Dashing())
        {   
            ChangeAnimationState("PlayerIdle");
        }
        else if(Time.time < end_dash_time && Dashing())
        {
            this.Dash();
        }
    }
    protected void Dash()
    {
        transform.position += new Vector3(PlayerManager.Instance.player_direction * this.dash_force * Time.deltaTime, 0, 0);
    }

    void ChangeAnimationState(string newAnimation)
    {
        if (PlayerManager.Instance.current_animation == newAnimation) return;
        //animations.SetAnimation(newAnimation);
        PlayerManager.Instance.current_animation = newAnimation;
    }

    protected bool Dashing()
    {
        if (PlayerManager.Instance.current_animation != "PlayerDash") return false;
        return true;
    }
    protected void isJump()
    {

    }*/
}


