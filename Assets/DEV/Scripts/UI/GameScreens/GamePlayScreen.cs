using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GamePlayScreen : GameScreen
{
    #region Fields
    [SerializeField] TextMeshProUGUI scoreText;
    #endregion
    public override void Show()
    {
        base.Show();
        scoreText.text = "Score: " + PlayerDataModel.Data.Score;
    }
    #region Executes
    public void UpdateScore(float amount)
    {
        scoreText.text = "Score: " + amount;
    }
    #endregion
}
