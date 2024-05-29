using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager: OnionBehaviour, IDataPersistance
{
    public float model_scale_x;
    public float model_scale_y;

    public float player_direction;

    public bool is_dashing = false;

    private LevelConfigs all_level_configs;

    private LevelConfig level_config;
    public LevelConfig _Level_Config => level_config;


    public static PlayerManager Instance;
    [SerializeField] public List<GameObject> game_object;

    [SerializeField] public bool is_using_skill = false;
    public Vector2 slope_normal_perp;

    private float exp_left;

    [Header("Player Attributes")]
    private int level;
    public int Level
    {
        get { return level; }
        set { level = value; }
    }

    private float exp_max;
    public float ExpMax
    {
        get { return exp_max; }
        set { exp_max = value; }
    }
    [SerializeField] private float current_exp;
    public float CurrentExp => current_exp;

    private float health;
    public float Health => health;

    private float current_hp;
    public float CurrentHP => current_hp;

    private float mana;
    public float Mana
    {
        get { return mana; }
        set { mana = value; }
    }

    private float current_mana;
    public float CurrentMana
    {
        get { return current_mana; }
        set { current_mana = value; }
    }

    private float mana_recover;
    public float ManaRecover
    {
        get { return mana_recover; }
        set { mana_recover = value; }
    }

    private float strength;
    public float CurrentStrength
    {
        get { return strength; }
        set { strength = value; }
    }

    [Range(0f, 100f)]
    private float dodge_rate;
    public float DodgeRate
    {
        get { return dodge_rate; }
        set { dodge_rate = value;}
    }
    private float health_recover;
    public float HealthRecover
    {
        get { return health_recover; }
        set { health_recover = value; }
    }

    [Range(0f, 100f)]
    private float crit_rate;
    public float CritRate
    {
        get { return crit_rate; }
        set { crit_rate = value; }
    }

    private float crit_mult;
    public float CritMult
    {
        get { return crit_mult; }
        set { crit_mult = value; }
    }

    private float base_dame;
    public float BaseDame
    {
        get { return base_dame; }
        set { base_dame = value; }
    }

    [Range(0f, 50f)]
    private float damage_redution;
    public float DamageRedution
    {
        get { return damage_redution; }
        set { damage_redution = value; }
    }

    public float coin;
    public float gem;

    private void Awake()
    {
        if (PlayerManager.Instance == null)
        {
            PlayerManager.Instance = this;
        }
        else
        {
            Debug.Log("Nhiều hơn 1 PlayerManger");
        }
        
    }
    void Start()
    {
        this.LoadComponent();
    }

    void Update()
    {
        this.ConstraintRotation();
        this.AddExp(exp_left);
        this.AddHp(health_recover * Time.deltaTime);
    }
    protected override void LoadComponent()
    {
        this.GetLevelConfigs();
        DataPersistaceManager.instance.LoadSaveSlot();
        this.GetLevelConfig(level);
        this.LoadModelScale();
        this.LoadDirection();
        this.LoadExP();
    }

    public void RotatePlayer()
    {
        Vector3 new_scale = new Vector3(player_direction * model_scale_x,this.model_scale_y, 1f);
        gameObject.transform.localScale = new_scale;
    }
    protected void LoadModelScale()
    {
        this.model_scale_x = 1.5f;
        this.model_scale_y = 1.5f;
    }
    protected void LoadDirection()
    {
        this.player_direction = 1f;
    }
    private void LoadExP()
    {
        this.exp_left = 0f;
    }
    protected void ConstraintRotation()
    {
        transform.localRotation = Quaternion.identity;
    }
    public Animator GetAnimator()
    {
        return GetComponent<Animator>();
    }
    public Rigidbody2D GetRigidbody()
    {
        return GetComponent<Rigidbody2D>();
    }
    private void GetLevelConfigs()
    {
        this.all_level_configs = InGameManager.Instance.GetAllLevelConfigs();
    }
    
    public void AddHp(float value )
    {
        if (current_hp > 0)
        {
            if ((current_hp + value) > health)
            {
                current_hp = health;
            }
            else
            {
                current_hp += value;
            }
        }
    }
    public void AddMana(float value)
    {
        if((current_mana + value) > mana)
        {
            current_mana = mana;
        }
        else
        {
            current_mana += value;
        }
    }
    public void MinusHp(float value)
    {
        if ((current_hp - value) < 0)
        {
            current_hp = 0;
        }
        else
        {
            current_hp -= value;
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
    private void GetLevelConfig(int id)
    {
        for(int i = 0; i < all_level_configs.lv_config.Count; i++)
        {
            if (all_level_configs.lv_config[i].level == id)
            {
                exp_max = all_level_configs.lv_config[i].exp;
                health = all_level_configs.lv_config[i].health;
                mana = all_level_configs.lv_config[i].mana;
                mana_recover = all_level_configs.lv_config[i].mana_recover;
                strength = all_level_configs.lv_config[i].strength;
                dodge_rate = all_level_configs.lv_config[i].dodge_rate;
                health_recover = all_level_configs.lv_config[i].health_recover;
                crit_rate = all_level_configs.lv_config[i].crit_rate;
                crit_mult = all_level_configs.lv_config[i].crit_mult;
                base_dame = all_level_configs.lv_config[i].base_dame;
                damage_redution = all_level_configs.lv_config[i].damage_redution;
            }
        }
    }
    public void AddExp(float value)
    {
        if(current_exp + value > exp_max)
        {
            exp_left = value - (exp_max - current_exp);
        }
        else 
        {
            current_exp += value;
            exp_left = 0;
        }
        if(exp_left != 0 && current_exp == exp_max)
        {
            if(all_level_configs.lv_config.Count == level)
            {
                return;
            }
            else
            {
                this.level = level + 1;
                GetComponent<PlayerExp>().SetTextLevel(level);
                GetLevelConfig(level);
                current_exp = 0f;
                Debug.Log("level " + level);
            }
        }
    }

    public void LoadGame(SaveSlot save_slot)
    {
        current_hp = save_slot.hp;
        current_mana = save_slot.mana;
        level = save_slot.level;
        current_exp = save_slot.exp;
        coin = save_slot.coin;
        gem = save_slot.gem;
        GetComponent<PlayerExp>().SetTextLevel(level);
        GetLevelConfig(level);
        Debug.Log("Đã load game");
    }

    public void SaveGame(ref SaveSlot save_slot)
    {
        save_slot.hp = this.health;
        save_slot.mana = this.mana;
        save_slot.level = this.level;
        save_slot.exp = this.current_exp;
        save_slot.coin = this.coin;
        save_slot.gem = this.gem;
    }
    private void OnApplicationQuit()
    {
        DataPersistaceManager.instance.SaveGame();
    }
}

