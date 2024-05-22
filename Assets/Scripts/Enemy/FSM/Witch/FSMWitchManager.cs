using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMWitchManager : MonoBehaviour
{
    [SerializeField] FSMWitchBase current_state;
    public FSMWitchChase witch_chase;
    public FSMWitchIdle witch_idle;
    public FSMWitchHeal witch_heal;
    public FSMWitchAttack witch_attack;
    public FSMWitchAttackFast witch_attack_fast;
    public Transform ball_lightning_prefabs;
    public Transform heal_wave_prefabs;
    public Transform spawn_point;


    public Rigidbody2D rigidbody;
    [SerializeField] public static FSMWitchManager Instance;
    private void Awake()
    {
        FSMWitchManager.Instance = this;
        this.witch_chase = gameObject.AddComponent<FSMWitchChase>();
        this.witch_idle = gameObject.AddComponent<FSMWitchIdle>();
        this.witch_heal = gameObject.AddComponent<FSMWitchHeal>();
        this.witch_attack = gameObject.AddComponent<FSMWitchAttack>();
        this.witch_attack_fast = gameObject.AddComponent<FSMWitchAttackFast>();
        this.rigidbody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        current_state = witch_idle;
        current_state.EnterState();
    }

    
    void Update()
    {
        current_state.UpdateState();
    }
    public void SwitchState(FSMWitchBase state)
    {
        current_state = state;
        current_state.EnterState();
    }

}
