using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SaveableObject<T> : MonoBehaviour, ISaveable where T: GameData, new()
{
    private ISaveableComponent[] saveableComponents;
    [SerializeField] protected string _fileName;
    protected T gameData;

    public T GameData { get => gameData; set => gameData = value; }

    private void Awake()
    {
        Debug.Log(gameObject.name);
        //var saveTemp = GetComponentsInChildren<ISaveableComponent<GameData>>();
        saveableComponents = GetComponentsInChildren<ISaveableComponent>();
    }

    protected virtual void OnEnable()
    {
        SaveManager.instance.SubscribeSaveableObject(this);
    }

    protected virtual void OnDisable()
    {
        SaveManager.instance.UnsubscribeSaveableObject(this);
    }

    public virtual void LoadAll()
    {
        SaveManager.instance.LoadFromFile(out gameData, _fileName);
        FetchGameData();
    }

    public void FetchGameData()
    {
        if (gameData == null) return;
        foreach (var saveableComp in saveableComponents)
        {
            gameData = saveableComp.Load(gameData) as T;
        }
    }

    public virtual ReturnedSaveableData SaveAll()
    {
        ReturnedSaveableData saveableTemp = new ReturnedSaveableData();
        saveableTemp.fileName = _fileName;
        GenerateGameData();
        saveableTemp.data = gameData;
        return saveableTemp;
    }

    public void GenerateGameData()
    {
        gameData = new T();
        foreach (var saveableComp in saveableComponents)
        {
            gameData = saveableComp.Save(gameData) as T;
        }
    }

}
