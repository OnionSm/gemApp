using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DecisionDetectPlayer : FSMDecision
{
    [SerializeField] private EnemyCore enemyCore;
    [SerializeField][Range(1f, 500f)] private float radius = 300f;
    [SerializeField] private LayerMask Player;
    private bool isDeteted;
    // Start is called before the first frame update
    private void Awake()
    {
        enemyCore = GetComponent<EnemyCore>();
    }

    // Update is called once per frame


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(enemyCore.transform.position, radius);
    }

    public override bool Decision()
    {
        return FindTargetFollow();
    }
    private bool FindTargetFollow()
    {
        Collider2D target = Physics2D.OverlapCircle(enemyCore.transform.position, radius, Player);
        if (target != null)
        {
            enemyCore.target = target.transform;
            return true;
            /*OnDecisionDetected?.Invoke(enermy);*/
        }
        else
        {
            enemyCore.target = null;
            return false;
            /*NoOnDecisionDetected?.Invoke();*/
        }

    }
}
