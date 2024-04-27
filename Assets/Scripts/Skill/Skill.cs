using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : OnionBehaviour
{
    public string arrow_prefab_name;
    public float skill_time;
    public float cold_down;
    public Vector3 enemy_position;

    [SerializeField] protected Transform spawn_point;
    
    public virtual void ActiveSkill()
    {
        
    }
}
