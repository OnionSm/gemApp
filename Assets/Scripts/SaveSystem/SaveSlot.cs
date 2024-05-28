using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveSlot 
{
    public string character_name;
    public int level;
    public int map_id;
    public Vector3 position;
    public float hp;
    public float exp;
    public float mana;
    public SaveSlot()
    {
        character_name = "";
        level = 1;
        map_id = 1;
        position = new Vector3(480, 100, 0);
        hp = 400f;
        exp = 0f;
        mana = 100f;
}

}
