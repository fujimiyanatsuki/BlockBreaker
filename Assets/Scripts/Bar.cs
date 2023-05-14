using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;
using DG.Tweening;

public class Bar : MonoBehaviour
{
    /// <summary>
    /// 移動にかかる時間
    /// </summary>
    private float moveDuration = 0.1f;

    /// <summary>
    /// リセットする際のポジション
    /// </summary>
    private Vector3 resetPosition = new Vector3(0, -4, 0);

    /// <summary>
    /// マウスを動かした際のイベントを発行
    /// </summary>
    private Subject<Unit> mouseMoveSubject = new Subject<Unit>();

    /// <summary>
    /// Barの移動制限範囲
    /// </summary>
    private float minX = -7.75f, maxX = 7.75f;

    /// <summary>
    /// Start
    /// </summary>
    private void Start()
    {
        this.UpdateAsObservable()
            .Select(_ => Camera.main.ScreenToViewportPoint(Input.mousePosition).x)
            .Pairwise()
            .Subscribe(_ => mouseMoveSubject.OnNext(Unit.Default));
    }

    /// <summary>
    /// Barの位置をリセット
    /// </summary>
    public void ResetBarPosition()
    {
        transform.position = resetPosition;
    }

    /// <summary>
    /// Barの移動
    /// </summary>
    public void MoveBar()
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float clampedX = Mathf.Clamp(mouseWorldPosition.x, minX, maxX);
        transform.DOMoveX(clampedX, moveDuration).SetEase(Ease.Linear).SetUpdate(true);
    }

    /// <summary>
    /// マウスを動かした際のイベントを通知
    /// </summary>
    public IObservable<Unit> OnMoveBar()
    {
        return mouseMoveSubject;
    }
}
