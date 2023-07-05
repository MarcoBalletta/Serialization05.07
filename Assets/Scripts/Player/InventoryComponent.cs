using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryComponent : MonoBehaviour, ISaveableComponent
{
    public int ammos;

    public GameData Load(GameData data)
    {
        if(data is PlayerData)
            ammos = (data as PlayerData).ammos;
        return data;
    }

    public GameData Save(GameData data)
    {
        if(data is PlayerData)
            (data as PlayerData).ammos = ammos;
        return data;
    }
}
