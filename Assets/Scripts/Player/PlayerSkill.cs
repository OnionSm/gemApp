using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : PlayerManager
{
    [SerializeField] private PlayerAnimation animations;
  

    private void Awake()
    {
        this.animations = GetComponent<PlayerAnimation>();
       /* if(bullet_prefab == null)
        {
            this.bullet_prefab = GameObject.Find("BulletManaget/Prefabs/Arrow");
        }*/
    }

    void Start()
    {
        
    }
}
