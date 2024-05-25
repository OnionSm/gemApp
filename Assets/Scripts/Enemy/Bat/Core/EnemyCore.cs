using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCore : MonoBehaviour
{
    public FSMState currentState { get; set; }
    public Transform target { get; set; }
    public string initState = "Wander";
    public List<FSMState> states;
    private EnemyHealth enemy_health;
    private void Awake()
    {
        this.enemy_health = GetComponent<EnemyHealth>();
    }
    private void Start()
    {
       currentState = GetState(initState);
    }


    private void Update()
    {
        if (enemy_health != null &&  enemy_health.CurrentHealth > 0)
        {
            currentState?.UpdateStateEnermy(this);
        }
    }

    public void ChangeState(string newStateID)
    {
        FSMState newState = GetState(newStateID);
        if (newState == null) return;
        currentState = newState;
    }


    private FSMState GetState(string newStateID)
    {
        foreach (FSMState state in states) 
        {
            if (state.ID == newStateID) 
                return state;
        }
        return null;
    }
}
