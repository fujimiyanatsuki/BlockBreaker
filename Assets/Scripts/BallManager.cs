using UniRx;
using UnityEngine;

public class BallManager : SingletonBase<BallManager>
{
    public GameObject BallPrefab;
    private GameObject currentBall;

    /// <summary>
    /// Ballに関する初期処理
    /// </summary>
    public void Initialize()
    {
        if (currentBall == null)
        {
            CreateBall();
            currentBall.GetComponent<Ball>().LaunchIBall();
        }
    }

    /// <summary>
    /// Ballを生成
    /// </summary>
    public void CreateBall()
    {
        currentBall = Instantiate(BallPrefab);
        currentBall.GetComponent<Ball>()
            .OnFallBall()
            .Subscribe(_ => CallGameOver())
            .AddTo(this);
        currentBall.SetActive(true);
    }

    /// <summary>
    /// Ballの削除処理を呼び出し
    /// </summary>
    public void DestroyBall()
    {
        if (currentBall != null)
        {
            currentBall.GetComponent<Ball>().DestroyBall();
            currentBall = null;
        }
    }

    /// <summary>
    /// ゲームオーバー時の処理を呼び出し
    /// </summary>
    private void CallGameOver()
    {
        StateManager.Instance.OnGameOver();
    }
}