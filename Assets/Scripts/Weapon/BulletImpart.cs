using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletImpart : OnionBehaviour
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

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.effect_prefab_name = "HitEffect";
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        SendDamage(collider);
        Debug.Log(collider.gameObject.name);
        if (collider.gameObject.layer == 10)
            return;
        Transform arrow = EffectSpawner.Instance.Spawn(effect_prefab_name, transform.position, new Vector3(1, 1, 1));
        arrow.gameObject.SetActive(true);
        SendDamage(collider);

    }
    private void SendDamage(Collider2D collider)
    {
        collider.gameObject.GetComponent<IDamageable>()?.TakeDamage(damage);
    }


}
        