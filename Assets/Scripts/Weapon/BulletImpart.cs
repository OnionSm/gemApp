using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class BulletImpart : MonoBehaviour
{
    [SerializeField] private string effect_prefab_name;
    [SerializeField] private float damage;
    public float Damage
    {
        get { return damage; }
        set { damage = value; }
    }
    private void Awake()
    {

    }
    private void Start()
    {
        this.LoadComponent();
    }

    protected void LoadComponent()
    {
        this.effect_prefab_name = "HitEffect";
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        bool check_dead = collider.gameObject.GetComponent<IDeadable>()?.IsDead() ?? false;
        if (collider.gameObject.layer == 10 ||  collider.gameObject.layer == 8 || check_dead)
            return;
        //GetComponent<Rigidbody2D>().isKinematic = true;
        Transform arrow = EffectSpawner.Instance.Spawn(effect_prefab_name, transform.position, new Vector3(1, 1, 1));
        arrow.gameObject.SetActive(true);
        SendDamage(collider);
        BulletSpawner.Instance.Despawn(gameObject.transform);

    }
    private void SendDamage(Collider2D collider)
    {
        collider.gameObject.GetComponent<IDamageable>()?.TakeDamage(damage);
    }


}
        