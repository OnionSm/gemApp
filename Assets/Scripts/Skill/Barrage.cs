using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrage : Skill

{
    [SerializeField] public static Barrage Instance;
    [SerializeField] private float arrow_speed;

    private void Awake()
    {
        Barrage.Instance = this;
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
        if (this.SkillAvailable() && PlayerManager.Instance.CurrentMana >= skill_mana_cost)
        {
            PlayerAnimation.Instance.SetTriggerBarrage();
            this.skill_time_count = this.skill_time;
            this.cool_down_time_count = this.cool_down;
            PlayerManager.Instance.MinusMana(skill_mana_cost);
            StartCoroutine(IEBarrageSkill());
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
        this.skill_mana_cost = 10f;

    }
    IEnumerator IEBarrageSkill()
    {
        yield return new WaitForSeconds(0.083f);
        for (int i = 0; i < 10; i++)
        {
            Transform arrow = BulletSpawner.Instance.Spawn(arrow_prefab_name, this.spawn_point.position, new Vector3(1, 1, 1));
            arrow.gameObject.SetActive(true);
            arrow.GetComponent<BulletImpart>().Damage = 38f;
            arrow.GetComponent<Rigidbody2D>().velocity = this.CalculateDirection() * this.arrow_speed;
            yield return new WaitForSeconds(0.116f);
        }
        yield return null;
    }
}
