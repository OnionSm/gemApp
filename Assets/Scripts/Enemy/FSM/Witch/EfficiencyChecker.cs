using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EfficiencyChecker : MonoBehaviour
{
    protected abstract void OnTriggerEnter2D(Collider2D collider);


    protected abstract void OnTriggerExit2D(Collider2D collider);
   
}
