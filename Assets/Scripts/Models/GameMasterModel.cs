using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMasterModel : MonoBehaviour
{
    private int score;
    private int lastLevel;
    private bool scoreCountable;
    public int Score { get => score; set => score = value; }
    public int LastLevel { get => lastLevel; set => lastLevel = value; }
    public bool ScoreCountable { get => scoreCountable; set => scoreCountable = value; }

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
