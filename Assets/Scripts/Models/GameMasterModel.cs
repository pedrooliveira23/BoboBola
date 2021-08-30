using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameMasterModel : MonoBehaviour
{
    [Serializable]
    public struct GameMasterModelAttributes
    {
        public int lastLevel;
    }

    [SerializeField]
    private GameMasterModelAttributes attributes;

    public int LastLevel { get => attributes.lastLevel; set => attributes.lastLevel = value; }

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
