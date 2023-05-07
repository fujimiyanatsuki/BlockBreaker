using UnityEngine;

public class BlockCounter : SingletonBase<BlockCounter>
{
    /// <summary>
    /// 現在のBlock数
    /// </summary>
    public int CurrentCount { get; private set; }

    /// <summary>
    /// Blockのカウントに関する初期処理
    /// </summary>
    /// <param name="initialCount"></param>
    public void Initialize(int initialCount)
    {
        CurrentCount = initialCount;
        Debug.Log("called Initialize:" + CurrentCount);
    }

    /// <summary>
    /// 現在のBlock数を減らす処理
    /// </summary>
    public void CountDownBlock()
    {
        CurrentCount--;
        Debug.Log("CurrentCount:" + CurrentCount);
    }
}
