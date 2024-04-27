using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISkill
{
    float skill_time { get; set; }
    float cold_down { get; set; }
    Vector3 enemy_position { get; set; }


    void ActiveSkill(); 

}
