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
        GameClear,
        /// <summary>
        /// リスタート
        /// </summary>
        ReStart
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
        CurrentState = GameState.GameOver;
        BallManager.Instance.DestroyBall();
        PanelManager.Instance.SetCanvas();
    }

    /// <summary>
    /// ゲームクリア時の処理
    /// </summary>
    public void OnGameClear()
    {
        CurrentState = GameState.GameClear;
        BallManager.Instance.DestroyBall();
        PanelManager.Instance.SetCanvas();        
    }

    /// <summary>
    /// リスタート時の処理
    /// </summary>
    public void OnRestartGame()
    {
        CurrentState = GameState.ReStart;
        PanelManager.Instance.SetCanvas();
        GameManager.Instance.InitializeGame();
        CurrentState = GameState.Playing;
    }    
}
