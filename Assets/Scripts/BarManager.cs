using UniRx;
using UnityEngine;

public class BarManager : SingletonBase<BarManager>
{
    public GameObject Bar;

    /// <summary>
    /// Barに関する初期処理
    /// </summary>
    public void Initialize()
    {
        Bar.GetComponent<Bar>()
            .OnMoveBar()
            .Subscribe(deltaX => Bar.GetComponent<Bar>().MoveBar(deltaX))
            .AddTo(this);
    }
}
