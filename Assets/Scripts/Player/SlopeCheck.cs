using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlopeCheck : MonoBehaviour
{
    [SerializeField] private CapsuleCollider2D check_point;
    [SerializeField] private LayerMask ground;
    private RaycastHit2D hit;



    [SerializeField] private Vector2 collider_size;
    [SerializeField] private float slope_check_distance = 25f;
        
    private float slope_down_angle;
    private float slope_down_angle_old;

    private bool is_on_slope;

    void Start()
    {
        check_point = GetComponent<CapsuleCollider2D>();
        collider_size = check_point.size;
    }

    // Update is called once per frame
    void Update()
    {
        this.CheckSlope();
    }
    protected void CheckSlope()
    {
        Vector2 check_pos = transform.parent.position - new Vector3(0f, collider_size.y / 2);
        SlopeCheckVertical(check_pos);
    }
    protected void SlopeCheckVertical(Vector2 check_pos)
    {
        hit = Physics2D.Raycast(check_pos, Vector2.down,slope_check_distance, ground);
        
        if (hit)
        {
            if(this.slope_down_angle != this.slope_down_angle_old)
            {
                this.is_on_slope = true;
            }
            this.slope_down_angle_old = this.slope_down_angle;

            PlayerManager.Instance.slope_normal_perp = -Vector2.Perpendicular(hit.normal);
            this.slope_down_angle = Vector2.Angle(hit.normal, Vector2.up);
            Debug.DrawRay(hit.point, PlayerManager.Instance.slope_normal_perp * 30f, Color.red);
            Debug.DrawRay(hit.point, hit.normal*30f, Color.green);
        }
    }
    protected void ApplyMovement()
    {
        /*if (is_ground && !is_on_slope)
        {


        }
        else if(is_ground && is_on_slope)
        {

        }*/
    }








}
