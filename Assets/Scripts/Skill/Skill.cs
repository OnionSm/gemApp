using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public string arrow_prefab_name;
    public float skill_time;
    public float cool_down;
    public Transform spawn_point;
    public float arrow_speed;   

    public float skill_time_count;
    public float cool_down_time_count;
    public float skill_mana_cost;
    public float skill_mult;
    public int skill_id;
    public string skill_name;

    public SkillConfig my_config;
    public virtual void ActiveSkill()
    {
        
    }
    public bool SkillAvailable()
    {
        if (!(skill_time_count <= 0 && cool_down_time_count <= 0))
            return false;
        return true;
    }
    public void DecreaseCoolDownTimeCount()
    {
        if (skill_time_count <= 0)
        {
            cool_down_time_count -= Time.deltaTime;
        }
    }
    public void DecreaseSkillTimeCount()
    {
        skill_time_count -= Time.deltaTime;
    }
    public bool IsHaveEnemy()
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
    public Vector3 GetEnemyPosition()
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
}
