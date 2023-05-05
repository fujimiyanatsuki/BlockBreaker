using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;

public class Bar : MonoBehaviour
{
    /// <summary>
    /// Barの移動速度にかける係数
    /// </summary>
    protected float Speed = 20.0f;

    /// <summary>
    /// マウスを動かした際のイベントを発行
    /// </summary>
    private Subject<float> mouseMoveSubject = new Subject<float>();

    /// <summary>
    /// Start
    /// </summary>
    void Start()
    {
        this.UpdateAsObservable()
            .Select(_ => Camera.main.ScreenToViewportPoint(Input.mousePosition).x)
            .Pairwise()
            .Subscribe(position => mouseMoveSubject.OnNext(position.Current - position.Previous));
    }

    /// <summary>
    /// Barの移動
    /// </summary>
    /// <param name="deltaX"></param>
    public void MoveBar(float deltaX)
    {
        transform.Translate(new Vector2(deltaX * Speed, 0));
    }

    /// <summary>
    /// マウスを動かした際のイベントを通知
    /// </summary>
    public IObservable<float> OnMoveBar()
    {
        return mouseMoveSubject;
    }
}
