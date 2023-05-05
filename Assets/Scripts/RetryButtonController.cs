using UnityEngine;
using UnityEngine.UI;

public class RetryButtonController : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            StateManager.Instance.OnRestartGame();
        });
    }
}
