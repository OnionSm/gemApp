using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : ScriptableObject
{
    [Header("Level of Player")]
    public int level;

    [Header("Health of Player")]
    public float Health;
    public float maxHealth;

    [Header("Mana of Player")]
    public float mana;
    public float maxMana;

    [Header("EXP of Player")]
    public float currentExp;
    public float expNextLevel;
    [Range(0f, 100f)] public float expMultiplier;


    [Header("Critical Damage of Player")]
    public float baseDamage;
    public float criticalChance;
    public float criticalDamage;

    [Header("Attribute")]
    public int atrributePoint;
    public int strength;
    public int dexterity;
    public int intelligence;

    [HideInInspector] public float totalExp;
    [HideInInspector] public float totalDamage;
}
