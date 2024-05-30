using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiShot : Skill
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
            Debug.Log("Multi Shot is activated");
            Vector3 spawn_pos = new Vector3(spawn_point.position.x, spawn_point.position.y + 5f, 0);
            PlayerAnimation.Instance.SetTriggerSpecialShot();
            this.skill_time_count = this.skill_time;
            this.cool_down_time_count = this.cool_down;
            PlayerManager.Instance.CurrentMana -= skill_mana_cost;
            AudioManager.Instance.PlayArrowSound();
            for (int i = 0; i < 3; i++)
            {
                Transform arrow = BulletSpawner.Instance.Spawn(arrow_prefab_name, spawn_pos, new Vector3(1, 1, 1));
                arrow.gameObject.SetActive(true);
                arrow.GetComponent<BulletImpart>().Damage = PlayerManager.Instance.BaseDame * skill_mult;
                arrow.GetComponent<Rigidbody2D>().velocity = this.CalculateDirection() * this.arrow_speed;
                spawn_pos = new Vector3(spawn_point.position.x, spawn_pos.y - 5f, 0);
            }
        }
    }

    protected void LoadComponent()
    {
        this.arrow_prefab_name = "BaseArrow";
        this.skill_id = 3;
        my_config = InGameManager.Instance.GetAnyConfigs(skill_id);
        if (my_config == null)
        {
            Debug.Log("Do not find any config for Multi Shot");
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
}
