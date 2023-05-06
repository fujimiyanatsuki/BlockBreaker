using UnityEngine;
using UnityEngine.UI;

public class CustomButton : MonoBehaviour
{
    public ButtonManager.ButtonActionType action;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            ButtonManager.Instance.HandleButtonClick(action);
        });
    }
}
