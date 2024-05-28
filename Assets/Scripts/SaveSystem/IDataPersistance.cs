using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDataPersistance 
{
    public void LoadGame(SaveSlot save_slot);
    public void SaveGame(ref SaveSlot save_slot);
}
