using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyConfigs", menuName = "Configs/EnemyConfigs")] 
public class EnemyConfigs : ScriptableObject
{
    public List<EnemyConfig> configs;
}
[System.Serializable]
public class EnemyConfig
{
    public int enemy_id;
    public float hp;
    public float mana;
    public float damage_mult;
    public float base_dame;
    

}

