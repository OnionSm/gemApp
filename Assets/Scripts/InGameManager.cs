using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : MonoBehaviour
{
    [SerializeField] private EnemyConfigs enemyConfigs;
    [SerializeField] private LevelConfigs all_level_configs;
    public static InGameManager Instance;
    // Start is called before the first frame update
    private void Awake()
    {
        InGameManager.Instance = this;
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

}
