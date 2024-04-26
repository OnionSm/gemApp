    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : OnionBehaviour
{
    [SerializeField] private float model_scale_x = 5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected void RotatePlayer(float value)
    {
        Vector3 new_scale = new Vector3(value * model_scale_x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
        gameObject.transform.localScale = new_scale;
    }
}
