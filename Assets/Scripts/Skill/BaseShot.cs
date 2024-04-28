using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BaseShot : Skill
{
    [SerializeField] public static BaseShot Instance;
    [SerializeField] private float arrow_speed;


    

    private void Awake()
    {
        BaseShot.Instance = this;
    }
    private void Start()
    {
        this.LoadComponent();
    }
    private void Update()
    {
        this.DecreaseSkillTimeCount();
        this.DecreaseSkillTimeCount();
    }


    public override void ActiveSkill()
    {
        if (!this.SkillAvailable())
            return;
        Transform arrow = BulletSpawner.Instance.Spawn(arrow_prefab_name,  this.spawn_point.position, new Vector3(1,1,1));
        arrow.gameObject.SetActive(true);
        arrow.GetComponent<Rigidbody2D>().velocity = this.CalculateDirection() * this.arrow_speed;
        this.skill_time_count = this.skill_time;
        this.cool_down_time_count = this.cool_down;
    }
    protected override void LoadComponent()
    {
        this.arrow_prefab_name = "BaseArrow";
        this.arrow_speed = 500f;
        this.cool_down = 0f;
        this.skill_time = 0.433f;
        this.skill_time_count = 0f;
        this.cool_down_time_count = 0f;

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
       if(this.IsHaveEnemy())
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
