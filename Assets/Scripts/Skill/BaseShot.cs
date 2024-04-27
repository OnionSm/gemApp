using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseShot : Skill
{
    [SerializeField] public static BaseShot Instance;

    

    private void Awake()
    {
        BaseShot.Instance = this;
    }


    public override void ActiveSkill()
    {
        
    }
    protected override void LoadComponent()
    {
        this.arrow_prefab_name = "BaseArrow";
    }

    protected Vector2 GetEnemyPosition()
    {
        if (EnemyCheckPos.Instance.have_enemy)
        {
            return EnemyCheckPos.Instance.enemy_pos;
        }
        else
        {
            return Vector2.right;
        }

    }
}
