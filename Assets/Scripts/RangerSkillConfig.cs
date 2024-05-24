using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangerSkillConfig : MonoBehaviour
{
    private SkillConfigs all_skill_configs;
    public  SkillConfigs AllSkillConfigs => all_skill_configs;
    private void Awake()
    {
        this.GetConfigs();
    }
    // Get all ranger skill config from ingamemanager
    private void GetConfigs()
    {
        all_skill_configs = InGameManager.Instance.GetAllSkillConfigs();
    }
    // Get config for any skill 
    public SkillConfig GetAnyConfigs(int id)
    {
        for(int i = 0; i< all_skill_configs.configs.Count;i++)
        {
            if (all_skill_configs.configs[i].id_skill == id)
            {
                return all_skill_configs.configs[i];

            }
        }
        return null;
    }
}
