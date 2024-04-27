using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : PlayerManager
{
    
    [SerializeField] private PlayerAnimation animations;

    [Header("Skill")]
    [SerializeField] private string skill_1;
    [SerializeField] private string skill_2;
    [SerializeField] private string skill_3;
    [SerializeField] private string skill_4;






    private void Awake()
    {
        this.animations = GetComponent<PlayerAnimation>();
       
    }

    void Start()
    {
        
    }


}
