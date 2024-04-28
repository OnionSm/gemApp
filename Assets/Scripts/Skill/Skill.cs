using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : OnionBehaviour
{
    public string arrow_prefab_name;
    public float skill_time;
    public float cool_down;
    public Transform spawn_point;

    public float skill_time_count;
    public float cool_down_time_count;
    
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
}
