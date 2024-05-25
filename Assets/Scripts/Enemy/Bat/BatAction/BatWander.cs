using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatWander : FSMAction
{

    private EnemyCore enemyCore;
    private EnemyAnimationManager animationManager;


    private void Awake()
    {
        enemyCore = GetComponent<EnemyCore>();
        this.animationManager = GetComponentInChildren<EnemyAnimationManager>();
    }

    // Start is called before the first frame update
    public override void Action()
    {
        this.Wandering();
    }
    private void Wandering()
    {
        Debug.Log("Wandering");

    }
}
