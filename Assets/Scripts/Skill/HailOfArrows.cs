using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HailOfArrows : Skill
{
    [SerializeField] public static HailOfArrows Instance;
    [SerializeField] private float arrow_speed;
    private List<double> angle_shot;

    private void Awake()
    {
        HailOfArrows.Instance = this;
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
        PlayerAnimation.Instance.SetTriggerAngleShot();
        this.skill_time_count = this.skill_time;
        this.cool_down_time_count = this.cool_down;
        foreach (float angle in angle_shot)
        {
            for (int i = 0; i <= 5; i++)
            {
                double random_angle = UnityEngine.Random.Range(angle - 3, angle + 3);
                double y_velocity = Mathf.Tan(Mathf.Deg2Rad);
                Transform arrow = BulletSpawner.Instance.Spawn(arrow_prefab_name, this.spawn_point.position, new Vector3(1, 1, 1));
                arrow.gameObject.SetActive(true);
                arrow.GetComponent<Rigidbody2D>().velocity = new Vector2(1, (float)y_velocity*5) * this.arrow_speed/3;
            }
        }
    }

    protected override void LoadComponent()
    {
        this.arrow_prefab_name = "DropArrow";
        this.angle_shot = new List<double>() { 45, 50, 60, 70, 80 };
        this.arrow_speed = 500f;
        this.cool_down = 1f;
        this.skill_time = 1.35f;
        this.skill_time_count = 0f;
        this.cool_down_time_count = 0f;
    }
}
