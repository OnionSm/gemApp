using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="Bow",menuName ="Items/Bow")]
public class Bow : ScriptableObject
{
    public List<BowAttributes> config_for_all_bows;
}

[System.Serializable]
public class BowAttributes : Items
{
    public int bow_id;
    public Sprite bow_icon;
    public int level;
    public int durability_max;
    public int gear_score;
    public float defense;
    public float health;
    public float health_regen;
    public float damage;
    public float mana_regen;
    public float selling_price;
}
