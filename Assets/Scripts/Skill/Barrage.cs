using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrage : Skill
{
   
    private void Start()
    {
        this.LoadComponent();
    }
    private void Update()
    {
        this.DecreaseSkillTimeCount();
        this.DecreaseCoolDownTimeCount();
    }

    public override void ActiveSkill()
    {
        if (this.SkillAvailable() && PlayerManager.Instance.CurrentMana >= skill_mana_cost)
        {
            Debug.Log("Barrage is activated");
            PlayerAnimation.Instance.SetTriggerBarrage();
            this.skill_time_count = this.skill_time;
            this.cool_down_time_count = this.cool_down;
            PlayerManager.Instance.MinusMana(skill_mana_cost);
            StartCoroutine(IEBarrageSkill());
        }
    }

    protected void LoadComponent()
    {
        this.arrow_prefab_name = "BaseArrow";
        this.skill_id = 2;
        my_config =  InGameManager.Instance.GetAnyConfigs(skill_id);
        if (my_config == null)
        {
            Debug.Log("Do not find any config for Barrage");
            return;
        }
        this.arrow_speed = 500f;
        this.cool_down = my_config.cool_down;
        this.skill_time = my_config.skill_cast;
        this.skill_time_count = 0;
        this.cool_down_time_count = 0f;
        this.skill_mult = my_config.skill_mult;
        this.skill_mana_cost = my_config.mana_cost;

    }
    IEnumerator IEBarrageSkill()
    {
        yield return new WaitForSeconds(0.083f);
        for (int i = 0; i < 10; i++)
        {
            AudioManager.Instance.PlaySFXSound("arrow");
            Transform arrow = BulletSpawner.Instance.Spawn(arrow_prefab_name, this.spawn_point.position, new Vector3(1, 1, 1));
            arrow.gameObject.SetActive(true);
            arrow.GetComponent<BulletImpart>().Damage = PlayerManager.Instance.BaseDame * skill_mult;
            arrow.GetComponent<Rigidbody2D>().velocity = this.CalculateDirection() * this.arrow_speed;
            yield return new WaitForSeconds(0.116f);
        }
        yield return null;
    }
}
