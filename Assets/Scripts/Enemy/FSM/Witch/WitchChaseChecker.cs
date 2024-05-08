using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchChaseChecker : EfficiencyChecker
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
            WitchManager.Instance.chasing = true;
        }

    }

    protected override void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.transform.tag == "Player")
        {
            WitchManager.Instance.chasing = false;
        }
    }
}
