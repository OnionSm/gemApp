using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="Pants",menuName ="Items/Pants")]
public class Pants : ScriptableObject
{
    public List<PantAttributes> config_for_all_pants;
}
[System.Serializable]
public class PantAttributes : Items
{
    public int pant_id;
    public Sprite pant_icon;
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
