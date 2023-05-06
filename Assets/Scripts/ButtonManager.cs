public class ButtonManager : SingletonBase<ButtonManager>
{
    public enum ButtonActionType
    {
        Retry
    }

    /// <summary>
    /// ボタンをクリックされた際の処理
    /// </summary>
    /// <param name="action"></param>
    public void HandleButtonClick(ButtonActionType action)
    {
        switch (action)
        {
            case ButtonActionType.Retry:
                StateManager.Instance.OnRestartGame();
                break;
        }
    }
}
