using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEfficiencyChecker : EfficiencyChecker
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.transform.tag=="Player")
        {
            WitchManager.Instance.in_attack_zone_ball_lighting = true;
        }
       
    }

    protected override void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.transform.tag == "Player")
        {
            WitchManager.Instance.in_attack_zone_ball_lighting = false;
        }
    }
}
