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
    protected void ActivateSkill(int skill_number)
    {
        string skill_name = this.GetSkillName(skill_number);
        SkillManager.Instance.GetSKill(skill_name);
    }
    protected string GetSkillName(int skill_number)
    {
        if (skill_number == 1)
        {
            return skill_1;
        }
        else if (skill_number == 2)
        {
            return skill_2;
        }
        else if (skill_number == 3)
        {
            return skill_3;
        }
        else if (skill_number == 4)
        {
            return skill_4;
        }
        else
            return null;
    }

}
