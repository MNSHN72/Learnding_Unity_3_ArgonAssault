using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScoreBoard : MonoBehaviour
{
    private int score = 0;
    private TMP_Text scoreText;
    private string format = "000000";

    //6 
    //5 0
    private void Start()
    {
        scoreText = this.GetComponent<TMP_Text>();
        scoreText.text = "000000";
    }
    public void IncreaseScore(int amountToIncrease) 
    {
        score += amountToIncrease;
    }

    private string FormattedScore(int score)
    {
        if (5-score.ToString().Length>=0)
        {
            return $"{format.Substring(0, (5 - score.ToString().Length))}{score}";
        }
        else
        {
            return score.ToString();
        }

    }
    public void UpdateUiScore() 
    {
        scoreText.text = FormattedScore(score);
    }
    
}
