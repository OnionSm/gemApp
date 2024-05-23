using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchManager : OnionBehaviour
{
    private float direct = 1f;
    
    [SerializeField] public static WitchManager Instance;

    [SerializeField] public float cool_down_time_skill;
    [SerializeField] public float cool_down_count;

    public bool in_attack_zone_water_push;
    public bool in_attack_zone_ball_lighting;
    public bool chasing;
    public EnemyConfig my_config;

    public int enemy_id;

    public float hp_current;
    public float hp_max;

    public float curent_mana;
    public float max_mana;


    private void Awake()
    {
        WitchManager.Instance = this;
    }
    void Start()
    {
        GetMyConfig();
        this.LoadComponent();
    }

    // Update is called once per frame
    void Update()
    {
        this.CountCoolDown();  

    }
    
    protected override void LoadComponent()
    {
        this.in_attack_zone_water_push = false;
        this.in_attack_zone_ball_lighting = false;
        this.chasing = false;
        this.cool_down_time_skill = 5f;
        this.cool_down_count = 0f;
        this.enemy_id = 0;
        this.hp_max = my_config.hp;
        this.hp_current = hp_max;
        this.max_mana = my_config.mana;
        this.curent_mana = max_mana;
        
    }
    protected void CountCoolDown()
    {
        if (this.cool_down_count <= 0) return;
        this.cool_down_count -= Time.deltaTime;
    }
    public void GetMyConfig()
    {
        EnemyConfigs enemy_all_config = InGameManager.Instance.GetAllConFigs();
        if (enemy_all_config != null)
        {
            for(int i = 0; i < enemy_all_config.configs.Count; i++)
            {
                if (enemy_all_config.configs[i].enemy_id == this.enemy_id)
                {
                    my_config = enemy_all_config.configs[i];
                }
            }
        }
    }
    public float GetDirect()
    {
        return direct;
    }
    public void SetDirect(float value)
    {
        this.direct = value;
    }
}
