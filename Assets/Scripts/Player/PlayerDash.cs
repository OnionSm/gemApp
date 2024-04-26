using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : OnionBehaviour
{

    public Rigidbody2D rigid_body;
    public Animator animations;
    [SerializeField] private float dash_force = 150f ;
    [SerializeField] private float dash_time = 0.567f;
    private bool can_dash;
    

    private void Awake()
    {
        this.rigid_body = PlayerManager.Instance.GetRigidbody();
        this.animations = PlayerManager.Instance.GetAnimator();
    }
    void Start()
    {
        this.LoadComponent();
    }

    
    void Update()
    {
        
    }

    public void CanDash()
    {
        if (this.can_dash)
        {
            StartCoroutine(Dashing());
            animations.Play("RG_Dash");
        }
    }

    protected IEnumerator Dashing()
    {
        can_dash = false;
        PlayerManager.Instance.is_dashing = true;
        rigid_body.velocity = new Vector2(PlayerManager.Instance.player_direction * dash_force, rigid_body.velocity.y);
        yield return new WaitForSeconds(dash_time);
        PlayerManager.Instance.is_dashing = false;
        can_dash = true;

    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.dash_force = 150f;
        this.dash_time = 0.7f;
        this.can_dash = true;
    }
}
