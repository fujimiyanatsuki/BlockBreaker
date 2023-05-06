using UniRx;
using UnityEngine;

public class BlockManager : SingletonBase<BlockManager>
{
    /// <summary>
    /// BlockのPrefab
    /// </summary>
    public GameObject BlockPrefab;

    /// <summary>
    /// 列数、行数
    /// </summary>
    private int rows, columns;

    /// <summary>
    /// X軸の隙間、Y軸の隙間
    /// </summary>
    private float blockXSpacing, blockYSpacing;

    /// <summary>
    /// Y軸の一番上の位置
    /// </summary>
    private float topPosition;


    /// <summary>
    /// Blockに関する初期処理
    /// </summary>
    public void Initialize(int rows, int columns, float blockXSpacing, float blockYSpacing, float topPosition)
    {
        this.rows = rows;
        this.columns = columns;
        this.blockXSpacing = blockXSpacing;
        this.blockYSpacing = blockYSpacing;
        this.topPosition = topPosition;

        LayoutBlocks();
    }

    /// <summary>
    /// Blockを指定した数だけ整列させます。
    /// </summary>
    private void LayoutBlocks()
    {
        // 画面の中央を計算するためのオフセット値を算出
        float centerOffsetX = (columns - 1) * (blockXSpacing + BlockPrefab.transform.localScale.x) / 2.0f;

        // 行の数だけループを回す
        for (int row = 0; row < rows; row++)
        {
            // それぞれの行におけるY座標を計算
            var tempY = topPosition - (blockYSpacing * row);

            // 列の数だけループを回す
            for (int column = 0; column < columns; column++)
            {
                // それぞれのブロックにおけるX座標を計算し、Vector3型のpositionを作成
                Vector3 position = new Vector3(
                    column * (blockXSpacing + BlockPrefab.transform.localScale.x) - centerOffsetX, tempY, 0);
                GameObject blockInstance = CreateBlock(position);
                SubscribeToBlockEvents(blockInstance);
                blockInstance.SetActive(true);
            }
        }
    }

    private GameObject CreateBlock(Vector3 position)
    {
        GameObject blockInstance = Instantiate(BlockPrefab, position, Quaternion.identity);
        blockInstance.transform.SetParent(transform);
        return blockInstance;
    }

    private void SubscribeToBlockEvents(GameObject blockInstance)
    {
        blockInstance.GetComponent<Block>()
            .OnCollideBall()
            .Subscribe(_ => OnCollideBlock(blockInstance))
            .AddTo(this);
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
