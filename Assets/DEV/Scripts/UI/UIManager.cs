using GameEnums;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region Fields
    [SerializeField] private GameScreen[] screens;
    private GameScreen activeScreen;
    public static UIManager Instance;
    #endregion

    #region Core
    public void Initialize()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        foreach (var screen in screens)
        {
            screen.gameObject.SetActive(true);
            screen.Initialize();
        }
    }
    #endregion

    #region Screen Executes
    public void ChangeScreen(ScreenTags screenType)
    {
        if (ReferenceEquals(activeScreen, null))
        {
            activeScreen = screens[(int)screenType];
            activeScreen.Show();
        }
        else
        {
            if (screens[(int)screenType] == activeScreen)
            {
                return;
            }
            activeScreen.Hide();
            activeScreen = screens[(int)screenType];
            activeScreen.Show();
        }
    }
    #endregion

    public void UpdateScore(float amount)
    {
        (screens[(int)ScreenTags.GamePlayScreen] as GamePlayScreen).UpdateScore(amount);
    }
}
