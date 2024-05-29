using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Pauldrons", menuName = "Items/Pauldrons")]
public class Pauldrons : ScriptableObject
{
    public List<PauldronAttributes> config_for_all_pauldrons;
}
[System.Serializable]
public class PauldronAttributes : Items
{
    public int pauldron_id;
    public Sprite pauldron_icon;
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
