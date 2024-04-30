using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiShot : Skill
{
    [SerializeField] public static MultiShot Instance;
    [SerializeField] private float arrow_speed;

    private void Awake()
    {
        MultiShot.Instance = this;
    }

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
        if (!this.SkillAvailable())
            return;
        Vector3 spawn_pos = new Vector3(spawn_point.position.x, spawn_point.position.y + 5f, 0);
        PlayerAnimation.Instance.SetTriggerSpecialShot();
        this.skill_time_count = this.skill_time;
        this.cool_down_time_count = this.cool_down;
        for (int i = 0; i < 3; i++)
        {
            Transform arrow = BulletSpawner.Instance.Spawn(arrow_prefab_name, spawn_pos, new Vector3(1, 1, 1));
            arrow.gameObject.SetActive(true);
            arrow.GetComponent<Rigidbody2D>().velocity = this.CalculateDirection() * this.arrow_speed;
            spawn_pos = new Vector3(spawn_point.position.x, spawn_pos.y - 5f, 0);
        }
    }

    protected override void LoadComponent()
    {
        this.arrow_prefab_name = "BaseArrow";
        this.arrow_speed = 500f;
        this.cool_down = 1f;
        this.skill_time = 1.35f;
        this.skill_time_count = 0f;
        this.cool_down_time_count = 0f;

    }
}
