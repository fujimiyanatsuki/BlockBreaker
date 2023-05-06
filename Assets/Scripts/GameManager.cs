public class GameManager : SingletonBase<GameManager>
{
    /// <summary>
    /// Awake
    /// </summary>
    protected override void Awake()
    {
        base.Awake();
        InitializeGame();
    }

    /// <summary>
    /// ゲームに必要な初期処理を実行
    /// </summary>
    public void InitializeGame()
    {
        BlockManager.Instance.Initialize();
        BlockCounter.Instance.Initialize(BlockManager.Instance.GetAllBlockCount());
        BarManager.Instance.Initialize();
        BallManager.Instance.Initialize();
        PanelManager.Instance.Initialize();
    }
}
