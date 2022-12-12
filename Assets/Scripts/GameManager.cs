using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour //Polymorphism
{
    public static GameManager instance;
    public int score;
    public TextMeshProUGUI scoreholder;
    void Awake()
    {
        instance = this;
    }
    void Update()
    {
        ScoreTable();
    }

    public int AddScore(int amount)//INPUT METHODS||INPUT TRY-CATCH METHODS||OUTPUT METHODS
    {
        try
        {
            score += amount;
            return score;
        }
        catch
        {
            Debug.Log("Error");
            return score;
        }
    }

    void ScoreTable()
    {
        scoreholder.text = "SCORE : " + score;
    }
}
