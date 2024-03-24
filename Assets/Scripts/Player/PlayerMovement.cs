using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : OnionBehaviour
{
    [SerializeField] private GameObject player_model;
    [SerializeField] private float player_speed = 5f;
    [SerializeField] private float model_scale_x = 5f;
    [SerializeField] private float move_direction = 1f;
    [SerializeField] private PlayerAnimation animations;
    [SerializeField] private float jump_height = 5f;
    [SerializeField] private bool can_jumpping = false;
    [SerializeField] private Transform circle_jump_checking;
    [SerializeField] private LayerMask ground;
 
    private void Awake()
    {
        this.player_model = GameObject.Find("Player/Model");
        this.animations = GameObject.Find("Player/PlayerAnimations").GetComponent<PlayerAnimation>();
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        this.CanRunning();
        this.CanJumpping();    
    }
    protected void Moving()
    {
        transform.parent.position += new Vector3(this.move_direction * this.player_speed * Time.deltaTime, 0, 0);
    }
    protected void Jumpping()
    {
        transform.parent.position += new Vector3(this.jump_height * this.player_speed * Time.deltaTime, 0, 0);
    }
    protected void CanRunning()
    {
        if (Input.GetKey(KeyCode.A))
        {
            this.move_direction = -1;
            this.RotatePlayer(this.move_direction);
            this.Moving();
            animations.SetBoolRuningAnimation(true);
            return;
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.move_direction = 1;
            this.RotatePlayer(this.move_direction);
            this.Moving();
            animations.SetBoolRuningAnimation(true);
            return;
        }
        animations.SetBoolRuningAnimation(false);
    }
    protected void RotatePlayer(float value)
    {
        Vector3 new_scale = new Vector3(value * model_scale_x, player_model.transform.localScale.y, player_model.transform.localScale.z);
        player_model.transform.localScale = new_scale;
    }
    protected void CanJumpping()
    {
        this.can_jumpping = Physics2D.OverlapCircle(circle_jump_checking.position, 0.2f, ground);
        if ((Input.GetKey(KeyCode.Space)) && can_jumpping)
        {
            this.can_jumpping = false;
            this.RotatePlayer(this.move_direction);
            this.Jumpping();
            return;
        }
    }
}


