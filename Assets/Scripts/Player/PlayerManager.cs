using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager: OnionBehaviour
{
    public float model_scale_x;
    public float model_scale_y;

    public float player_direction;

    public float max_hp;
    public float current_hp;

    public float max_mana;
    public float current_mana;

    [SerializeField] public static PlayerManager Instance;
    [SerializeField] public List<GameObject> game_object;
    [SerializeField] public string current_animation;
    [SerializeField] public bool is_using_skill = false;
    private void Awake()
    {
        if (PlayerManager.Instance == null)
        {
            PlayerManager.Instance = this;
        }
        this.LoadComponent();
        
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    protected override void LoadComponent()
    {
        this.LoadModelScale();
        this.LoadDirection();
        this.LoadHP();
        this.LoadMana();
    }

    protected void RotatePlayer(float value)
    {
        Vector3 new_scale = new Vector3(value * model_scale_x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
        gameObject.transform.localScale = new_scale;
    }
    protected void LoadModelScale()
    {
        this.model_scale_x = 1f;
        this.model_scale_y = 1f;
    }
    protected void LoadDirection()
    {
        this.player_direction = 1f;
    }
    protected void LoadHP()
    {
        this.max_hp = 100f;
        this.current_hp = this.max_hp;
    }
    protected void LoadMana()
    {
        this.max_mana = 100f;
        this.current_mana = this.max_mana;
    }
}

