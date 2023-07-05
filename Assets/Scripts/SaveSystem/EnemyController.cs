using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, ISaveableComponent
{
    public GameData Load(GameData data)
    {
        if (data is EnemyData)
        {
            var dataTemp = data as EnemyData;
            gameObject.name = dataTemp.name;
            transform.position = dataTemp.position;
            transform.rotation = dataTemp.rotation;
            return dataTemp;
        }

        return data;
    }

    public GameData Save(GameData data)
    {
        if (data is EnemyData)
        {
            var dataTemp = data as EnemyData;
            dataTemp.name = gameObject.name;
            dataTemp.position = transform.position;
            dataTemp.rotation = transform.rotation;
            return dataTemp;
        }
        return data;
    }
}
