using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class Block : MonoBehaviour
{
    /// <summary>
    /// Blockの列数
    /// </summary>
    public int BlockRows { get; private set; } = 6;

    /// <summary>
    /// Blockの行数
    /// </summary>
    public int BlockColumns { get; private set; } = 14;

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
    /// OnEnable
    /// </summary>
    void OnEnable()
    {
        this.OnCollisionEnter2DAsObservable()
            .Subscribe(_ => blockCollideSubject.OnNext(Unit.Default));
    }

    /// <summary>
    /// Blockの削除処理
    /// </summary>
    public void DestroyBlock()
    {
        Destroy(gameObject);
    }

    /// <summary>
    /// Blockが別オブジェクトと衝突した際のイベントを通知
    /// </summary>
    public IObservable<Unit> OnCollideBall()
    {
        return blockCollideSubject;
    }
}