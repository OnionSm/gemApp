using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "LevelConfigs", menuName ="Level/LevelConfigs")]
public class LevelConfigs : ScriptableObject
{
    public List<LevelConfig> lv_config; 
}

[System.Serializable]
public class LevelConfig
{
    [Header("Level of Player")]
    public int level;

    [Header("Exp of Level")]
    public float exp;

    [Header("Health of Player")]
    public float health;

    [Header("Mana of Player")]
    public float mana;

    [Header("Mana recover per second")]
    public float mana_recover;

    [Header("Strength of Player")]
    public float strength;

    [Header("Dodge rate of Player")]
    [Range(0f,100f)]
    public float dodge_rate;

    [Header("Health recover per second")]
    public float health_recover;

    [Header("Crit rate")]
    [Range(0f, 100f)]
    public float crit_rate;

    [Header("Crit damage mult")]
    public float crit_mult;

    [Header("Base Damage")]
    public float base_dame;

    [Header("Damange Redution")]
    [Range(0f, 50f)]
    public float damage_redution;

}
        