using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{

    [SerializeField] protected float bullet_speed;
    [SerializeField] protected float bullet_direction;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    protected virtual void LoadDirection()
    {
        this.bullet_direction = gameObject.transform.localScale.x;
    }

    protected virtual void ArrowFly()
    {

    }
}
