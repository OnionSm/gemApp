using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReceiver : MonoBehaviour
{
    [SerializeField] private float enemy_hp;
    [SerializeField] private float max_hp = 10;
    private void Awake()
    {
        this.enemy_hp = max_hp;
    }
    private void Update()
    {
        this.Despawning();
    }
    public void DecreaseHP(float damage)
    {
        this.enemy_hp -= damage;
    }

    protected bool CanDespawn()
    {
        return enemy_hp <= 0;
    }
    protected void Despawn()
    {
        gameObject.SetActive(false);
    }
    protected void Despawning()
    {
        if (!this.CanDespawn()) return;
        this.Despawn();
    }
}
