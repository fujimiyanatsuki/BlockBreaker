public class GameManager : SingletonBase<GameManager>
{
    public int BlockRows { get; private set; } = 5;
    public int BlockColumns { get; private set; } = 8;
    public float BlockXOffset { get; private set; } = 1.2f;
    public float BlockYOffset { get; private set; } = 1.2f;

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
        BlockManager.Instance.Initialize(BlockRows, BlockColumns, BlockXOffset, BlockYOffset);
        BarManager.Instance.Initialize();
        BallManager.Instance.Initialize();
    }
}
