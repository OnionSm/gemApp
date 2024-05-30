using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyCheckPos : OnionBehaviour
{
    public static EnemyCheckPos Instance;
    public Vector3 enemy_pos;
    public bool have_enemy;


    private void Awake()
    {
        if (Instance == null)
        {
            EnemyCheckPos.Instance = this;
        }
        else
        {
            Debug.Log("More than one EnemyCheckPos");
        }
    }
    void Start()
    {
        this.LoadComponent();
    }

    
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        bool check_dead = other.gameObject.GetComponent<IDeadable>()?.IsDead() ?? false;
        if (other.CompareTag("Enemy") && !check_dead)
        {
            this.have_enemy = true;
            this.enemy_pos = other.transform.position;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        this.have_enemy = false;
    }
    protected override void LoadComponent()
    {
        this.have_enemy = false;
    }
}
