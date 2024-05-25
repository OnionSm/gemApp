using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionAttackPlayer : FSMDecision
{
    [SerializeField] private LayerMask Player;
    [SerializeField][Range(0, 50f)] private float attackRange;
    [SerializeField] private EnemyCore enemyCore;
    private void Awake()
    {
        enemyCore = GetComponent<EnemyCore>();
    }

    // Start is called before the first frame update
    void Start()
    {
        this.LoadComponent();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override bool Decision()
    {
        return IsAttackPlayer();
    }
    public bool IsAttackPlayer()
    {
        Collider2D collisionPlayer = Physics2D.OverlapCircle(enemyCore.transform.position, attackRange, Player);
        if (collisionPlayer != null)
        {
            enemyCore.target = collisionPlayer.transform;
            return true;
        }
        return false;
    }
    private void LoadComponent()
    {
        this.attackRange = 15f;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(enemyCore.transform.position, attackRange);
    }
}
