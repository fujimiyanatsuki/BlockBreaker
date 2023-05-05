using UniRx;
using UnityEngine;

public class BlockManager : SingletonBase<BlockManager>
{
    public GameObject BlockPrefab;

    /// <summary>
    /// Blockに関する初期処理
    /// </summary>
    public void Initialize(int rows, int columns, float xOffset, float yOffset)
    {
        CreateBlocks(rows, columns, xOffset, yOffset);
    }

    //ここはあとで綺麗に書く
    private void CreateBlocks(int rows, int columns, float xOffset, float yOffset)
    {
        // ブロック全体の幅と高さを計算
        float totalWidth = (columns - 1) * xOffset;
        float totalHeight = (rows - 1) * yOffset;

        // ブロック全体を中心に配置するためのオフセット
        float offsetX = totalWidth / 2.0f;
        float offsetY = totalHeight / 2.0f;

        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < columns; x++)
            {
                Vector3 position = new Vector3(x * xOffset - offsetX, y * yOffset - offsetY, 0);
                GameObject blockInstance = Instantiate(BlockPrefab, position, Quaternion.identity);
                blockInstance.transform.SetParent(transform);
                blockInstance.GetComponent<Block>()
                     .OnCollideBall()
                     .Subscribe(_ => OnCollideBlock(blockInstance))
                     .AddTo(this);
                blockInstance.SetActive(true);
            }
        }
    }

    /// <summary>
    /// BlockとBallがぶつかった時の処理
    /// </summary>
    /// <param name="block"></param>
    private void OnCollideBlock(GameObject block)
    {
        block.GetComponent<Block>().DestroyBlock();
        BlockCounter.Instance.CountDownBlock();
        if (BlockCounter.Instance.CurrentCount == 0) StateManager.Instance.OnGameClear();
    }
}
