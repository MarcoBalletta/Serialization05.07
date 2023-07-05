using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class EnemiesSavesHandler : SaveableObject<EnemiesData>
{
    public List<EnemySaveableObject> enemies;

    public override ReturnedSaveableData SaveAll()
    {
        ReturnedSaveableData returnedData = new ReturnedSaveableData();
        returnedData.fileName = _fileName;
        gameData = new EnemiesData();
        gameData.enemies = new EnemyData[enemies.Count];
        for(int i = 0; i< gameData.enemies.Length; i++)
        {
            enemies[i].GenerateGameData();
            gameData.enemies[i] = enemies[i].GameData;
        }
        //foreach (var enemy in enemies)
        //{
        //    enemy.GenerateGameData();
        //    gameData.enemies.(enemy.GameData);
        //}
        returnedData.data = gameData;
        return returnedData;
    }

    public override void LoadAll()
    {
        SaveManager.instance.LoadFromFile(out gameData, _fileName);
        if (gameData == null) return;
        foreach (var enemy in enemies)
        {
            enemy.GameData = gameData.enemies[enemies.IndexOf(enemy)];
            enemy.FetchGameData();
        }
    }
}
