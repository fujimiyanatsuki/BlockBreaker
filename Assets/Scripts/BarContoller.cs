using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class BarContoller : MonoBehaviour
{
    void Start()
    {
        this.UpdateAsObservable()
            .Select(_ => Camera.main.ScreenToViewportPoint(Input.mousePosition).x)
            .Pairwise()
            .Subscribe(position =>
            {
                var deltaX = position.Current - position.Previous;
                transform.Translate(new Vector2(deltaX * 20, 0));
            });
    }
}
