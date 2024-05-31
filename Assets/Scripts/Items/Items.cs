using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public enum Type
{
    Helmet,
    Chestplate,
    Gauntlets,
    Bow,
    Pauldrons,
    Pants,
    Boots,
    Shield,
    Potion,
    Resource,
    Food
}
public enum Rarity
{
    Common,
    Rare,
    Epic,
    Legendary
}
public class Items  
{
    public Type type;
    public Rarity rarity;
}
