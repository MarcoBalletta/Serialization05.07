using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISaveableComponent
{
    public GameData Save(GameData data);
    public GameData Load(GameData data);
}
