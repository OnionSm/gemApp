using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchManager : OnionBehaviour
{
    [SerializeField] public float direct = 1f;
    [SerializeField] public float witch_hp_current;
    [SerializeField] public float witch_hp_max;
    [SerializeField] public static WitchManager Instance;
    [SerializeField] private float witch_scale_x;
    [SerializeField] private float witch_scale_y;

    [SerializeField] public float cool_down_time_skill;
    [SerializeField] public float cool_down_count;

    public bool in_attack_zone_water_push;
    public bool in_attack_zone_ball_lighting;
    public bool chasing;
    private void Awake()
    {
        WitchManager.Instance = this;
    }
    void Start()
    {
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
            transform.localScale = new Vector3(witch_scale_x , witch_scale_y, 1);
        }
        else
        {
            this.direct = -1f;
            transform.localScale = new Vector3(-witch_scale_x , witch_scale_y, 1);
        }
    }
    protected override void LoadComponent()
    {
        this.witch_hp_current = 100f;
        this.witch_hp_max = 100f;
        this.witch_scale_x = 1.5f;
        this.witch_scale_y = 1.5f;
        this.in_attack_zone_water_push = false;
        this.in_attack_zone_ball_lighting = false;
        this.chasing = false;
        this.cool_down_time_skill = 5f;
        this.cool_down_count = 0f;
    }
    protected void CountCoolDown()
    {
        if (this.cool_down_count <= 0) return;
        this.cool_down_count -= Time.deltaTime;
    }
}
