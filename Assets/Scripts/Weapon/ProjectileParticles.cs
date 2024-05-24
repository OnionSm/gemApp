using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileParticles : MonoBehaviour
{
    [SerializeField] private Rigidbody2D particles;
    private bool ground_trigger = false;


    private void Awake()
    {
        this.particles = GetComponent<Rigidbody2D>();
    }

    protected void Update()
    {
        if(ground_trigger == false)
            this.RotateArrow();
    }

    protected void RotateArrow()
    {
        float angle = Mathf.Atan2(particles.velocity.y, particles.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    public void Reload()
    {
        particles.isKinematic = false;
    }
}
