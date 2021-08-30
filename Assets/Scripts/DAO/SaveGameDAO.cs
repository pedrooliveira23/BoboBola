using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveGameDAO
{
    private string saveFile;
    private static SaveGameDAO _instance;

    private SaveGameDAO()
    {
        saveFile = Application.persistentDataPath + "/gamedata.json";
    }

    public static SaveGameDAO GetInstance()
    {
        if (_instance == null)
        {
            _instance = new SaveGameDAO();
        }
        return _instance;
    }

    public void Create(SaveGameModel saveGameModel)
    {
        File.WriteAllText(saveFile, JsonUtility.ToJson(saveGameModel));
    }

    public SaveGameModel Read()
    {
        return JsonUtility.FromJson<SaveGameModel>(File.ReadAllText(saveFile));
    }

    public void Update(SaveGameModel saveGameModel)
    {
        Delete();
        Create(saveGameModel);
    }

    public void Delete()
    {
        File.Delete(saveFile);
    }
}
