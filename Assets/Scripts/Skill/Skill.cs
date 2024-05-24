using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public string arrow_prefab_name;
    public float skill_time;
    public float cool_down;
    public Transform spawn_point;

    public float skill_time_count;
    public float cool_down_time_count;
    public float skill_mana_cost;
    public float skill_mult;
    public int skill_id;
    public string skill_name;

    public SkillConfig my_cofig;
    public virtual void ActiveSkill()
    {
        
    }
    protected bool SkillAvailable()
    {
        if (!(skill_time_count <= 0 && cool_down_time_count <= 0))
            return false;
        return true;
    }
    protected void DecreaseCoolDownTimeCount()
    {
        if (skill_time_count <= 0)
        {
            cool_down_time_count -= Time.deltaTime;
        }
    }
    protected void DecreaseSkillTimeCount()
    {
        skill_time_count -= Time.deltaTime;
    }
    protected bool IsHaveEnemy()
    {
        if (EnemyCheckPos.Instance.have_enemy)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
    protected Vector3 GetEnemyPosition()
    {
        return EnemyCheckPos.Instance.enemy_pos;
    }
    protected Vector2 CalculateDirection()
    {
        if (this.IsHaveEnemy())
        {
            Vector3 enemy_pos = GetEnemyPosition();
            Vector3 arrow_direct = (enemy_pos - this.spawn_point.position).normalized;

            Vector2 arrow_direct_2d = new Vector2(arrow_direct.x, arrow_direct.y);
            return arrow_direct_2d;
        }
        else
        {
            return new Vector2(PlayerManager.Instance.player_direction, 0);
        }
    }
    public void GetAnyConfigs(int id)
    {
        SkillConfigs all_skill_configs =  InGameManager.Instance.GetAllSkillConfigs();
        if(all_skill_configs == null) { return; }
        for (int i = 0; i < all_skill_configs.configs.Count; i++)
        {
            if (all_skill_configs.configs[i].id_skill == id)
            {
                my_cofig =  all_skill_configs.configs[i];
                return;
            }
        }
    }
}
