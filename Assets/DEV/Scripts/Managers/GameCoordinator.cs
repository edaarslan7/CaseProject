using System.Collections.Generic;
using UnityEngine;

public class GameCoordinator : MonoBehaviour
{
    #region Fields
    [SerializeField] private GameplayData gameData;
    [SerializeField] private List<Controller> controllers;
    #endregion

    #region Core
    public void Initialize()
    {
        controllers.ForEach(x => x.Initialize(gameData));
    }
    public void StartGame()
    {
        
    }
    #endregion

    #region Executes

    #endregion
}
