using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLightningMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(100f*Time.deltaTime*WitchManager.Instance.direct,0f,0f));
    }

}
