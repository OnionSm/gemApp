using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseShot : ISkill
{
    [SerializeField] private Vector2 shot_direct;

    public float skill_time { get; set; }
    public float cold_down { get; set; }
    public Vector3 enemy_position { get; set; }


    public void ActiveSkill()
    {

    }
    protected void LoadComponent()
    {
        this.shot_direct = new Vector2(PlayerManager.Instance.player_direction, 0);
    }
}
