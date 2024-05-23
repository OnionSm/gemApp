using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HailOfArrows : Skill
{
    [SerializeField] public static HailOfArrows Instance;
    [SerializeField] private float arrow_speed;
    private List<float> angle_shot;
    private List<float> distances;
    private List<float> time_arrow_fly;
    private List<float> x_velo;
    private List<float> y_velo;

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
        if (this.SkillAvailable() && PlayerManager.Instance.CurrentMana >= skill_mana_cost)
        {
            PlayerAnimation.Instance.SetTriggerAngleShot();
            this.skill_time_count = this.skill_time;
            this.cool_down_time_count = this.cool_down;

            PlayerManager.Instance.CurrentMana -= skill_mana_cost;
            StartCoroutine(Skill());
        }
    }

    protected override void LoadComponent()
    {
        this.arrow_prefab_name = "DropArrow";
        this.angle_shot = new List<float>() {80, 75, 70, 65, 60};
        this.arrow_speed = 500f;
        this.cool_down = 1f;
        this.skill_time = 1.35f;
        this.skill_time_count = 0f;
        this.cool_down_time_count = 0f;
        this.distances = new List<float>() {120, 210, 280, 330, 360};
        this.time_arrow_fly = new List<float>() { 1.55f, 1.5f, 1.45f, 1.4f, 1.35f };
        this.x_velo = new List<float>() { 80, 140, 187, 220, 240 };
        this.y_velo = new List<float>() { 370, 350, 330, 310,290};
        this.skill_mana_cost = 25f;
    }
    IEnumerator Skill()
    {
        for (int i = 0; i < 5; i++)
        {

            for (int j = 0; j < 3; j++)
            {
                yield return new WaitForSeconds(0.005f);
                float x_velocity = x_velo[i] + Random.Range(0,20);
                float y_velocity = y_velo[i] + Random.Range(0, 20);
                Transform arrow = BulletSpawner.Instance.Spawn(arrow_prefab_name, this.spawn_point.position, new Vector3(1, 1, 1));
                arrow.gameObject.SetActive(true);
                arrow.GetComponent<BulletImpart>().Damage = 100f;
                arrow.GetComponent<Rigidbody2D>().velocity = new Vector2(x_velocity * PlayerManager.Instance.player_direction, y_velocity);
                arrow.GetComponent<ProjectileParticles>().Reload();
                
            }
            yield return new WaitForSeconds(0.02f);
        }
        yield return null;
    }
}
