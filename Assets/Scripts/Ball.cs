using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class Ball : MonoBehaviour
{
    /// <summary>
    /// Ballの速度
    /// </summary>
    protected float Speed = 5.0f;

    /// <summary>
    /// 画面下部にある見えない壁のタグ
    /// </summary>
    private string tagWall = "Wall";

    /// <summary>
    /// Ballが落下した際のイベントを発行
    /// </summary>
    private Subject<Unit> ballFallSubject = new Subject<Unit>();

    /// <summary>
    /// OnEnable
    /// </summary>
    void OnEnable()
    {
        this.OnCollisionEnter2DAsObservable()
            .Where(collision => collision.gameObject.CompareTag(tagWall))
            .Subscribe(_ => ballFallSubject.OnNext(Unit.Default));
    }

    /// <summary>
    /// Ballの発射処理
    /// </summary>
    public void LaunchIBall()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(Speed, Speed));
    }

    /// <summary>
    /// Ballの削除処理
    /// </summary>
    public void DestroyBall()
    {
        Destroy(gameObject);
    }

    /// <summary>
    /// Ballが落下した際のイベントを通知
    /// </summary>
    public IObservable<Unit> OnFallBall()
    {
        return ballFallSubject;
    }
}
