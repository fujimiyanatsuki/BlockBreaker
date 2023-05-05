using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class Block : MonoBehaviour
{
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
