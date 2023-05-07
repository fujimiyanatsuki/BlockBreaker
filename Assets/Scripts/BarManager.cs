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
            .Subscribe(_ => Bar.GetComponent<Bar>().MoveBar())
            .AddTo(this);
        Bar.GetComponent<Bar>().ResetBarPosition();
    }
}
