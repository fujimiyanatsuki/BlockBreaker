using UnityEngine;
using UnityEngine.UI;

public class CustomButton : MonoBehaviour
{
    public ButtonManager.ButtonActionType ButtonActionType;

    /// <summary>
    /// Start
    /// </summary>
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            ButtonManager.Instance.HandleButtonClick(ButtonActionType);
        });
    }
}
