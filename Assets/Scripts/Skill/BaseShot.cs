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
        this.DecreaseCoolDownTimeCount();
    }


    public override void ActiveSkill()
    {
        if (!this.SkillAvailable())
            return;
        PlayerAnimation.Instance.SetTriggerBaseShot();
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
}
