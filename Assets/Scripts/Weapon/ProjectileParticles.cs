using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileParticles : MonoBehaviour
{
    [SerializeField] private Rigidbody2D particles;
    private bool ground_trigger = false;

    public bool DestroyOnDisable;
    private Vector2 LocalPositions;


    private void Awake()
    {
        this.particles = GetComponent<Rigidbody2D>();
    }

    protected void Update()
    {
        if(ground_trigger == false)
            this.RotateArrow();
    }

    private void OnEnable()
    {
    }

    private void Disable()
    {
    }
    protected void RotateArrow()
    {
        float angle = Mathf.Atan2(particles.velocity.y, particles.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer != 3)
            return;
        particles.velocity = Vector2.zero;
        ground_trigger = true;
        particles.isKinematic = true;
    }
    public void Reload()
    {
        this.ground_trigger = false;
        particles.isKinematic = false;
    }
}
