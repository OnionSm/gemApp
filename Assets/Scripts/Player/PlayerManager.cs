using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager: OnionBehaviour
{
    [SerializeField] private float model_scale_x = 5f;
    [SerializeField] public float player_direction = 1f;
    [SerializeField] public static PlayerManager Instance;
    private void Awake()
    {
        if(PlayerManager.Instance == null)
        {
            PlayerManager.Instance = this;
        }
    }
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
