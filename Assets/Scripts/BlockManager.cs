using DG.Tweening;
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
    public void Initialize()
    {
        this.rows = BlockPrefab.GetComponent<Block>().BlockRows;
        this.columns = BlockPrefab.GetComponent<Block>().BlockColumns;
        this.blockXSpacing = BlockPrefab.GetComponent<Block>().BlockXSpacing;
        this.blockYSpacing = BlockPrefab.GetComponent<Block>().BlockYSpacing;
        this.topPosition = BlockPrefab.GetComponent<Block>().BlockTopPosition;

        LayoutBlocks();
    }

    /// <summary>
    /// Block全体の個数を取得
    /// </summary>
    /// <returns></returns>
    public int GetAllBlockCount()
    {
        return BlockPrefab.GetComponent<Block>().GetAllBlockCount();
    }

    /// <summary>
    /// Blockの整列にかかる時間を測定
    /// </summary>
    /// <returns></returns>
    public float TotalLayoutTime()
    {　
        return (rows * 0.05f + (columns - 1) * 0.05f) + 0.1f;
    }

    /// <summary>
    /// すべてのブロックを削除
    /// </summary>
    public void AllDestroyBlocks()
    {
        Block[] blocks = FindObjectsOfType<Block>();
        foreach (Block block in blocks)
        {
            block.FadeOutAndFall();
        }
    }

    /// <summary>
    /// Blockを指定した数だけ整列
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

                var renderer = blockInstance.GetComponent<SpriteRenderer>();
                renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, 0);
                renderer.DOFade(1f, 0.1f).SetDelay(row * 0.05f + column * 0.05f);

                blockInstance.SetActive(true);
            }
        }
    }

    /// <summary>
    /// BlockをPrefabをもとに生成
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>
    private GameObject CreateBlock(Vector3 position)
    {
        GameObject blockInstance = Instantiate(BlockPrefab, position, Quaternion.identity);
        blockInstance.transform.SetParent(transform);
        return blockInstance;
    }

    /// <summary>
    /// Blockが衝突した際のイベントを購読
    /// </summary>
    /// <param name="blockInstance"></param>
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
