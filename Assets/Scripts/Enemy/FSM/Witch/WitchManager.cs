using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchManager : OnionBehaviour
{
    [SerializeField] public float direct = 1f;
    
    [SerializeField] public static WitchManager Instance;
    [SerializeField] private float witch_scale_x;
    [SerializeField] private float witch_scale_y;

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
        this.LookAtPlayer();
        this.CountCoolDown();  

    }
    protected void LookAtPlayer()
    {
        Vector3 player_pos = PlayerManager.Instance.transform.position;
        if(player_pos.x >= transform.position.x)
        {
            this.direct = 1f;
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            this.direct = -1f;
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }
    protected override void LoadComponent()
    {
        this.witch_scale_x = 1.5f;
        this.witch_scale_y = 1.5f;
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
}
