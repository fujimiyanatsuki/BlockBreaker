public class ButtonManager : SingletonBase<ButtonManager>
{
    /// <summary>
    /// ボタンの種別
    /// </summary>
    public enum ButtonActionType
    {
        Retry
    }

    /// <summary>
    /// ボタンをクリックされた際の処理
    /// </summary>
    /// <param name="type"></param>
    public void HandleButtonClick(ButtonActionType type)
    {
        switch (type)
        {
            case ButtonActionType.Retry:
                StateManager.Instance.OnRestartGame();
                break;
        }
    }
}
