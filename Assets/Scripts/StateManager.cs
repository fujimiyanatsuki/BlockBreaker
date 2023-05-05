using UnityEngine.SceneManagement;

public class StateManager : SingletonBase<StateManager>
{
    /// <summary>
    /// ゲームの状態をあらわすクラス
    /// </summary>
    public enum GameState
    {
        /// <summary>
        /// プレイ中
        /// </summary>
        Playing,
        /// <summary>
        /// ゲームオーバー
        /// </summary>
        GameOver,
        /// <summary>
        /// ゲームクリア
        /// </summary>
        GameClear
    }

    /// <summary>
    /// ゲームの現在の状態
    /// </summary>
    public GameState CurrentState { get; private set; } = GameState.Playing;

    /// <summary>
    /// ゲームオーバー時の処理
    /// </summary>
    public void OnGameOver()
    {
        BallManager.Instance.DestroyBall();
        PanelManager.Instance.ActiveGameOverPanel();
        CurrentState = GameState.GameOver;
    }

    /// <summary>
    /// ゲームクリア時の処理
    /// </summary>
    public void OnGameClear()
    {
        BallManager.Instance.DestroyBall();
        PanelManager.Instance.ActiveClearPanel();
        CurrentState = GameState.GameClear;
    }

    /// <summary>
    /// リスタート時の処理
    /// </summary>
    public void OnRestartGame()
    {
        PanelManager.Instance.HidePanel();
        GameManager.Instance.InitializeGame();
        CurrentState = GameState.Playing;
    }    
}
