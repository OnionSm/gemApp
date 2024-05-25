using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class FSMTransition 
{
    public FSMDecision decide;
    public string trueState;
    public string falseState;
}
