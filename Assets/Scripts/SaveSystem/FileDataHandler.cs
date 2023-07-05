using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;
using System.Text;
using Newtonsoft.Json;

public class FileDataHandler
{

    private string _directory;

    public FileDataHandler(string directory)
    {
        _directory = directory;
    }
    
    public void WriteInFile(ReturnedSaveableData returnedData)
    {

        string dir = Path.Combine(Application.dataPath, _directory);

        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

        string fullPath = Path.Combine(dir, returnedData.fileName);
        if (returnedData.data is EnemiesData)
        {
            Debug.Log("Enemies");
        }
        string json = JsonUtility.ToJson(returnedData.data);

        //string json = JsonConvert.SerializeObject(returnedData.data);

        using (FileStream stream = new FileStream(fullPath, FileMode.OpenOrCreate))
        {
            using (StreamWriter writer = new StreamWriter(stream))
            {
                writer.Write(json);
            }
        }
    }

    public T ReadFromFile<T>(string fileName) where T: GameData
    {
        T data = null;
        string fullPath = Path.Combine(Application.dataPath, _directory, fileName);
        if (File.Exists(fullPath))
        {
            string dataString = null;
            using (FileStream stream = new FileStream(fullPath, FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    dataString = reader.ReadToEnd();
                }
            }
            data = JsonUtility.FromJson<T>(dataString);
        }
        else
        {
            Debug.Log("Save file not found");
        }
        return data;
    }
}
