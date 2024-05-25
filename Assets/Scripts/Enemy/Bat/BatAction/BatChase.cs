using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class BatChase : FSMAction
{
    [SerializeField] private EnemyCore enemyCore;
    [SerializeField] [Range(0f, 100f)] float speed_chase;
    private EnemyAnimationManager animationManager;


    private void Awake()
    {
        enemyCore = GetComponent<EnemyCore>();
        this.animationManager = GetComponentInChildren<EnemyAnimationManager>();
    }

    // Start is called before the first frame update
    public override void Action()
    {
        this.ChasingPlayer();
    }
    private void ChasingPlayer()
    {
        if (enemyCore.target == null) 
            return;
        Vector3 dirOfPlayer = enemyCore.target.position - transform.position;
        transform.Translate(dirOfPlayer.normalized * speed_chase * Time.deltaTime);
    }
}
