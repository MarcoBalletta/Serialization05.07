using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISaveable
{
    public ReturnedSaveableData SaveAll();
    public void LoadAll();
}

[System.Serializable]
public struct ReturnedSaveableData
{
    public string fileName;
    public GameData data;
}
