using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfficiencyWitchCheckerPush : EfficiencyChecker
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.transform.tag == "Player")
        {
            WitchManager.Instance.in_attack_zone_water_push = true;
        }

    }

    protected override void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.transform.tag == "Player")
        {
            WitchManager.Instance.in_attack_zone_water_push = false;
        }
    }
}
