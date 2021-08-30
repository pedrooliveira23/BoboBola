using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class SaveGameModel
{
    [SerializeField]
    private int levelIndex;

    public SaveGameModel(int levelIndex)
    {
        this.levelIndex = levelIndex;
    }

    public int LevelIndex { get => levelIndex; set => levelIndex = value; }
}
