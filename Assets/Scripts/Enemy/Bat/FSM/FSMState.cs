using System.Collections.Generic;
using System;
[Serializable]
public class FSMState 
{
    public string ID;
    public FSMAction[] allActions;
    public FSMTransition[] allTransistions;


    public void UpdateStateEnermy(EnemyCore enermyCore)
    {
        ExcuteActions();
        ExcuteTransistionEnermy(enermyCore);
    }

    private void ExcuteActions()
    {
        foreach (FSMAction action in allActions)
        {
            action.Action();
        }
    }


    private void ExcuteTransistionEnermy(EnemyCore core)
    {
        foreach (FSMTransition transistion in allTransistions)
        {
            bool isTrueState = transistion.decide.Decision();
            if (isTrueState)
                core.ChangeState(transistion.trueState);
            else
                core.ChangeState(transistion.falseState);
        }
    }

}
