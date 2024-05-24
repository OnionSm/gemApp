using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillConfigs", menuName ="Skill/SkillConfigs")]
public class SkillConfigs : ScriptableObject
{
    public List<SkillConfig> configs;
}
[System.Serializable]
public class SkillConfig
{
    [Header("ID of Skill")]
    public int id_skill;

    [Header("Skill name")]
    public string skill_name;

    [Header("Mult of Skill")]
    public float skill_mult;

    [Header("Skill Cast")]
    public float skill_cast;

    [Header("Cooldown of Skill")]
    public float cool_down;

    [Header("Mana cost")]
    public float mana_cost;
}
