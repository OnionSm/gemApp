using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : MonoBehaviour
{
    [SerializeField] private EnemyConfigs enemyConfigs;
    [SerializeField] private LevelConfigs all_level_configs;
    [SerializeField] private SkillConfigs all_skill_configs;
    [SerializeField] private Audios all_audio_configs;


    public static InGameManager Instance;
    // Start is called before the first frame update
    private void Awake()
    {
        if(Instance == null) 
        {
            InGameManager.Instance = this;
        }
        else
        {
            Debug.Log("More than one InGameManager");
        }
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public EnemyConfigs GetAllConFigs()
    {
        return enemyConfigs;
    }
    public LevelConfigs GetAllLevelConfigs()
    {
        return all_level_configs;
    }
    public SkillConfigs GetAllSkillConfigs() 
    {
        return all_skill_configs;
    }
    public Audios GetAllAudiosConfigs()
    {
        return all_audio_configs;
    }
    public SkillConfig GetAnyConfigs(int id)
    {
        for (int i = 0; i < all_skill_configs.configs.Count; i++)
        {
            if (all_skill_configs.configs[i].id_skill == id)
            {
                return all_skill_configs.configs[i];
            }
        }
        return null;
    }
}
