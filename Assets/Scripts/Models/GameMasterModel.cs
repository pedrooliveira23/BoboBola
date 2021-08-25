using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMasterModel : MonoBehaviour
{
    private int lastLevel;
    public int LastLevel { get => lastLevel; set => lastLevel = value; }

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
