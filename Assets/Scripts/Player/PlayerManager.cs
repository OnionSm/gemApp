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

    public bool is_dashing = false; 


   

    public static PlayerManager Instance;
    [SerializeField] public List<GameObject> game_object;

    [SerializeField] public bool is_using_skill = false;
    public Vector2 slope_normal_perp;
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
        this.ConstraintRotation();
        CheckMaxHp();
        CheckMaxMana();
    }
    protected override void LoadComponent()
    {
        this.LoadModelScale();
        this.LoadDirection();
        this.LoadHP();
        this.LoadMana();
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
    protected void LoadHP()
    {
        this.max_hp = 1000f;
        this.current_hp = this.max_hp;
    }
    protected void LoadMana()
    {
        this.max_mana = 100f;
        this.current_mana = this.max_mana;
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
    private void CheckMaxHp()
    {
        if (current_hp > max_hp)
        {
            max_hp = current_hp;
        }
    }
    private void CheckMaxMana()
    {
        if (current_mana > max_mana)
        {
            current_mana = max_mana;
        }
    }
}

