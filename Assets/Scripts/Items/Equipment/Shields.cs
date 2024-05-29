using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Shields",menuName = "Items/Shields")]
public class Shields : ScriptableObject
{
    public List<ShieldAttributes> config_for_all_shields;
}
[System.Serializable]
public class ShieldAttributes : Items
{
    public int shield_id;
    public Sprite shield_icon;
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
