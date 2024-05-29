using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Helmet",menuName ="Items/Helmet")]
public class HelmetItems : ScriptableObject
{
    public List<HelmetAttributes> config_for_all_helmets;
}
[System.Serializable]
public class HelmetAttributes : Items
{
    public int helmet_id;
    public Sprite helmet_icon;
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
