public class GameManager : SingletonBase<GameManager>
{
    public int BlockRows { get; private set; } = 5;
    public int BlockColumns { get; private set; } = 14;
    public float BlockXSpacing { get; private set; } = 0.1f;
    public float BlockYSpacing { get; private set; } = 0.4f;
    public float BlockTopPosition { get; private set; } = 4f;

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
        BlockCounter.Instance.Initialize(BlockRows * BlockColumns);
        BlockManager.Instance.Initialize(BlockRows, BlockColumns, BlockXSpacing, BlockYSpacing, BlockTopPosition);
        BarManager.Instance.Initialize();
        BallManager.Instance.Initialize();
    }
}
