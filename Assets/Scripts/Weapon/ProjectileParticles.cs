using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileParticles : MonoBehaviour
{
    [SerializeField] private Rigidbody2D particles;

    public bool DestroyOnDisable;

    private Vector2 LocalPositions;

    private void Awake()
    {
    }

    private void OnEnable()
    {
    }

    private void Disable()
    {
    }
}
