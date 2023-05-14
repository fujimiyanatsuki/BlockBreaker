using System.Collections;
using UnityEngine;

public class GameManager : SingletonBase<GameManager>
{
    /// <summary>
    /// Awake
    /// </summary>
    protected override void Awake()
    {
        base.Awake();
    }

    /// <summary>
    /// Start
    /// </summary>
    void Start()
    {
        InitializeGame();
    }

    /// <summary>
    /// ゲームに必要な初期処理を実行
    /// </summary>
    public void InitializeGame()
    {
        PanelManager.Instance.Initialize();
        BlockManager.Instance.Initialize();
        BlockCounter.Instance.Initialize(BlockManager.Instance.GetAllBlockCount());
        BarManager.Instance.Initialize();
        StartCoroutine(WaitForBlocksAndInitializeBall());
    }

    /// <summary>
    /// Blockの整列が完了するまで待機
    /// </summary>
    /// <returns></returns>
    private IEnumerator WaitForBlocksAndInitializeBall()
    {
        yield return new WaitForSeconds(BlockManager.Instance.TotalLayoutTime());
        BallManager.Instance.Initialize();
    }
}
