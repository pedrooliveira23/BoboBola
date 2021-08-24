using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreModel : MonoBehaviour
{
    public int score;
    public int Score { get => score; set => score = value; }

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
