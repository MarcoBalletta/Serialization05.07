using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{

    private const string directory = "Savings";

    public static SaveManager instance;
    private FileDataHandler _dataHandler;
    private List<ISaveable> saveableObjects = new List<ISaveable>();
    private void Awake()
    {
        instance = this;
        _dataHandler = new FileDataHandler(directory);
    }

    // Start is called before the first frame update
    void Start()
    {
        Load();
    }

    public void Load()
    {
        foreach (var saveable in saveableObjects)
        {
            saveable.LoadAll();
        }
    }

    public void Save()
    {
        foreach(var saveable in saveableObjects)
        {
            _dataHandler.WriteInFile(saveable.SaveAll());
        }
    }

    public void SubscribeSaveableObject(ISaveable saveable)
    {
        if (!saveableObjects.Contains(saveable))
        {
            saveableObjects.Add(saveable);
        }
    }

    public void UnsubscribeSaveableObject(ISaveable saveable)
    {
        if (!saveableObjects.Contains(saveable))
        {
            saveableObjects.Remove(saveable);
        }
    }

    public void LoadFromFile<T>(out T data, string fileName) where T: GameData
    {
        data = _dataHandler.ReadFromFile<T>(fileName);
    }
}
