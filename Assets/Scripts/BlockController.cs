using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    void Start()
    {
        this.OnCollisionEnter2DAsObservable()
            .Subscribe(_ =>
            {
                GameManager.Instance.BlockBreak();
                Destroy(gameObject);
            });
    }
}
