using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigid_body;
    [SerializeField] private GameObject player_model;
    [SerializeField] private float player_speed = 5f;
    [SerializeField] private float model_scale_x = 5f;
    [SerializeField] private float move_direction = 1f;
    [SerializeField] private PlayerAnimation animations;
    [SerializeField] private float jump_height = 5f;
    [SerializeField] private Vector2 jump_direction;
 
    private void Awake()
    {
        this.player_model = GameObject.Find("Player/Model");
        this.rigid_body = this.player_model.GetComponent<Rigidbody2D>();
        this.animations = GameObject.Find("Player/PlayerAnimations").GetComponent<PlayerAnimation>();
        this.jump_direction.x = 0f;
        this.jump_direction.y = 5f;
    }
    void Start()
    {
        
    }

    
    void Update()
    {
       this.CanMoving();
    }
    protected void Moving()
    {
        /*rigid_body.MovePosition(rigid_body.position + move_direction * player_speed * Time.fixedDeltaTime);*/
        transform.parent.position += new Vector3(this.move_direction * this.player_speed * Time.deltaTime, 0, 0);
    }
    protected void Jumpping()
    {
        rigid_body.MovePosition(rigid_body.position + jump_direction * player_speed * Time.fixedDeltaTime);
        Debug.Log(jump_direction);
    }
    protected void CanMoving()
    {
        if(Input.GetKey(KeyCode.A))
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
        if (Input.GetKey(KeyCode.Space))
        {
            this.Jumpping();
            animations.SetBoolJumppingAnimation(true);
            return;
        }
        animations.SetBoolRuningAnimation(false);
    }
    protected void RotatePlayer(float value)
    {
        Vector3 new_scale = new Vector3(value * model_scale_x, player_model.transform.localScale.y, player_model.transform.localScale.z);
        player_model.transform.localScale = new_scale;
    }
}
