using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchHp : EnemyHP, IDamageable
{
    private float time_to_disappear = 10f;
    private float count_to_disappear = 10f;
    [SerializeField] private SpriteRenderer model;
    [SerializeField] private Rigidbody2D rigid_body;
    private void Awake()
    {
        rigid_body = GetComponent<Rigidbody2D>();
    }
    public override void Update()
    {
        base.Update();
        DismissModel();
    }
    public override void GainHP(float value)
    {
        WitchManager.Instance.AddHp(value);
    }
    public override void DecreaseHP(float value)
    {
        WitchManager.Instance.MinusHp(value);
    }
    public override void SetHealthBar()
    {
        float hp_fill = WitchManager.Instance.CurrentHp / WitchManager.Instance.MaxHP;
        if (hp_fill != health_bar.fillAmount)
        {
            health_bar.fillAmount = hp_fill;
        }
    }

    public void TakeDamage(float amount)
    {
        WitchManager.Instance.MinusHp(amount);
    }

    public override void CheckDead()
    {
        if (is_alive)
        {
            if (WitchManager.Instance.CurrentHp <= 0)
            {
                rigid_body.isKinematic = true;
                rigid_body.velocity = Vector3.zero;
                Death();
                DestroyWitch();
            }
        }
    }

    public override void Death()
    {
        PlayerManager.Instance.AddExp(50f);
        FSMWitchManager.Instance.SwitchState(FSMWitchManager.Instance.witch_dead);
        WitchManager.Instance.WitchCanvas.gameObject.SetActive(false);
        is_alive = false;
    }
    private void DismissModel()
    {
        if (WitchManager.Instance.CurrentHp <= 0)
        {
            count_to_disappear -= Time.deltaTime;
            if (model != null)
            {
                Color color = model.color;
                color.a = Mathf.Clamp01(count_to_disappear / 5f);
                model.color = color;
            }
        }
    }
    IEnumerator DestroyWitch()
    {
        yield return new WaitForSeconds(time_to_disappear);
        Destroy(gameObject);
        yield return null;
    }
}
