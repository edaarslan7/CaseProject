using UnityEngine;
using GameEnums;

public class GameManager : MonoBehaviour
{
    #region Fields
    [SerializeField] GameCoordinator gameCoordinator;
    [SerializeField] UIManager uiManager;
    [SerializeField] DataHandler dataHandler;
    [SerializeField] PlayerMovement player;
    public static GameManager Instance;
    private GameStates currentGameState;
    #endregion

    #region Getters
    public GameStates CurrentGameState => currentGameState;
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
        dataHandler.Initialize();
        gameCoordinator.Initialize();
        uiManager.Initialize();
        player.Initialize();
        ChangeGameState(GameStates.Loading);
    }

    private void Awake()
    {
        Initialize();
    }
    #endregion

    #region State Executes
    public void ChangeGameState(GameStates state)
    {
        currentGameState = state;
        OnGameStateChanged();
    }

    private void OnGameStateChanged()
    {
        switch (currentGameState)
        {
            case GameStates.Loading:
                loading();
                break;
            case GameStates.GamePlay:
                gamePlay(); 
                break;
        }
    }

    private void loading()
    {
        uiManager.ChangeScreen(ScreenTags.LoadingScreen);
    }

    private void gamePlay()
    {
        uiManager.ChangeScreen(ScreenTags.GamePlayScreen);
        gameCoordinator.StartGame();
    }

    public void OnGameLoaded()
    {
        ChangeGameState(GameStates.GamePlay);
    }
    #endregion

    public void OnQuitButtonClicked()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
