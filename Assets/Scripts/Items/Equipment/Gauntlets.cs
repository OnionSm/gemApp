using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Gauntlets", menuName = "Items/Gauntlets")]
public class Gauntlets : ScriptableObject
{
    public List<GauntletAttributes> config_for_all_gauntlets;
}
[System.Serializable]
public class GauntletAttributes : Items
{
    public int gauntlet_id;
    public Sprite gauntlet_icon;
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
