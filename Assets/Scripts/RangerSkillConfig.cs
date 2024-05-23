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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void GetConfigs()
    {
        all_skill_configs = InGameManager.Instance.GetAllSkillConfigs();
    }
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
