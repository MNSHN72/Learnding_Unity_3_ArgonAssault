using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    private int score = 0;
    public void IncreaseScore(int amountToIncrease) 
    {
        score += amountToIncrease;
    }
    public void PrintScoreToConsole() 
    {
        Debug.Log($"SCORE: {score}");
    }
}
