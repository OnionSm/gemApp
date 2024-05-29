using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="Boots",menuName ="Items/Boots")]
public class Boots : ScriptableObject 
{
    public List<BootsAttributes> config_for_all_boots;
}
[System.Serializable]
public class BootsAttributes : Items
{
    public int boot_id;
    public Sprite boot_icon;
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
