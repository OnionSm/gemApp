using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchManager : MonoBehaviour
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

    [SerializeField] private float hp_current;
    [SerializeField] public Canvas witch_canvas;
    public Canvas WitchCanvas => witch_canvas;
    public float CurrentHp
    {
        get { return hp_current; }
        set { hp_current = value; }
    }

    private float hp_max;
    public float MaxHP => hp_max;


    private float current_mana;
    public float CurrentMana => current_mana;
    private float max_mana;
    public float MaxMana => max_mana;


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
    
    protected void LoadComponent()
    {
        this.in_attack_zone_water_push = false;
        this.in_attack_zone_ball_lighting = false;
        this.chasing = false;
        this.cool_down_time_skill = 3f;
        this.cool_down_count = 0f;
        this.enemy_id = 0;
        this.hp_max = my_config.hp;
        this.hp_current = hp_max;
        this.max_mana = my_config.mana;
        this.current_mana = max_mana;
        
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

    public void AddHp(float value)
    {
        if ((hp_current + value) > hp_max)
        {
            hp_current = hp_max;
        }
        else
        {
            hp_current += value;
        }
    }
    public void AddMana(float value)
    {
        if ((current_mana + value) > max_mana)
        {
            current_mana = max_mana;
        }
        else
        {
            current_mana += value;
        }
    }
    public void MinusHp(float value)
    {
        if (hp_current == hp_max)
        { 
            witch_canvas.gameObject.SetActive(true);
        }
        if ((hp_current - value) < 0)
        {
            hp_current = 0;
        }
        else
        {
            hp_current -= value;
        }
    }
    public void MinusMana(float value)
    {
        if ((current_mana - value) < 0)
        {
            return;
        }
        else
        {
            current_mana -= value;
        }
    }
}
