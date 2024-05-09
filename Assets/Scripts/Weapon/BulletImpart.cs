using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletImpart : OnionBehaviour
{
    [SerializeField] private DamageSender damage_sender;
    [SerializeField] private string effect_prefab_name;
    private void Awake()
    {
        this.damage_sender = GetComponent<DamageSender>();
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
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.gameObject.layer == 3)
        {
            Transform arrow = EffectSpawner.Instance.Spawn(effect_prefab_name,transform.position, new Vector3(1, 1, 1));
            arrow.gameObject.SetActive(true);
            //this.damage_sender.Send(collision.transform);
        }

    }
    private void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject.layer == 3)
        {
            Transform arrow = EffectSpawner.Instance.Spawn(effect_prefab_name, transform.position, new Vector3(1, 1, 1));
            arrow.gameObject.SetActive(true);
            //this.damage_sender.Send(collision.transform);
        }

    }


}
        