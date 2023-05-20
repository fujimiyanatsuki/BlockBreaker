using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using DG.Tweening;

public class Block : MonoBehaviour
{
    /// <summary>
    /// Blockの列数
    /// </summary>
    public int BlockRows { get; private set; } = 3;

    /// <summary>
    /// Blockの行数
    /// </summary>
    public int BlockColumns { get; private set; } = 13;

    /// <summary>
    /// BlockのX軸の隙間
    /// </summary>
    public float BlockXSpacing { get; private set; } = 0.1f;

    /// <summary>
    /// BlockのY軸の隙間
    /// </summary>
    public float BlockYSpacing { get; private set; } = 0.4f;

    /// <summary>
    /// BlockのY軸の一番上の位置
    /// </summary>
    public float BlockTopPosition { get; private set; } = 4f;

    /// <summary>
    /// Blockが別オブジェクトと衝突した際のイベントを発行
    /// </summary>
    private Subject<Unit> blockCollideSubject = new Subject<Unit>();

    /// <summary>
    /// 透明度ゼロの数値
    /// </summary>
    private float alphaZero = 0f;

    /// <summary>
    /// 通常Blockが破壊される時にかかる時間
    /// </summary>
    private float normalFadeDuration = 0.3f;

    /// <summary>
    /// ゲームオーバーの際、Blockの破壊にかかる時間
    /// </summary>
    private float gameOverFadeDuration = 1.5f;

    /// <summary>
    /// ブロックが落下する最小速度
    /// </summary>
    private float MinFallSpeed = 0.5f;

    /// <summary>
    /// ブロックが落下する最大速度
    /// </summary>
    private float MaxFallSpeed = 1.5f;

    /// <summary>
    /// OnEnable
    /// </summary>
    void OnEnable()
    {
        this.OnCollisionEnter2DAsObservable()
            .Subscribe(_ => blockCollideSubject.OnNext(Unit.Default));
    }

    /// <summary>
    /// Blockの全個数を取得
    /// </summary>
    /// <returns></returns>
    public int GetAllBlockCount()
    {
        return BlockRows * BlockColumns;
    }

    /// <summary>
    /// Blockの削除処理
    /// </summary>
    public void DestroyBlock()
    {
        GetComponent<SpriteRenderer>().DOFade(alphaZero, normalFadeDuration).OnComplete(() =>
        {
            Destroy(gameObject);
        });
    }

    /// <summary>
    /// Blockが別オブジェクトと衝突した際のイベントを通知
    /// </summary>
    public IObservable<Unit> OnCollideBall()
    {
        return blockCollideSubject;
    }

    /// <summary>
    /// ブロックをフェードアウトしながら落下させる
    /// </summary>
    public void FadeOutAndFall()
    {
        float fallSpeed = UnityEngine.Random.Range(MinFallSpeed, MaxFallSpeed);
        float randomX = UnityEngine.Random.Range(-10f, 10f);
        float randomAngle = UnityEngine.Random.Range(0f, 360f);

        transform
            .DOMove(new Vector3(randomX, -10f, transform.position.z), fallSpeed)
            .SetEase(Ease.InCubic);
        transform
            .DORotate(new Vector3(0f, 0f, randomAngle), fallSpeed, RotateMode.FastBeyond360);
        GetComponent<SpriteRenderer>()
            .DOFade(alphaZero, gameOverFadeDuration)
            .OnComplete(() =>
        {
            Destroy(gameObject);
        });
    }
}
