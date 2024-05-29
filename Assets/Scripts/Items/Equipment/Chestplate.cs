using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Chestplate", menuName = "Items/Chestplate")]
public class Chestplate : ScriptableObject
{
    public List<ChestAttributes> config_for_all_chestplate;
}
[System.Serializable]
public class ChestAttributes : Items
{
    public int chestplate_id;
    public Sprite chestplate_icon;
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
