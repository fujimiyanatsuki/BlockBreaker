public class ButtonManager : SingletonBase<ButtonManager>
{
    public enum ButtonAction
    {
        Retry
    }

    /// <summary>
    /// ボタンをクリックされた際の処理
    /// </summary>
    /// <param name="action"></param>
    public void HandleButtonClick(ButtonAction action)
    {
        switch (action)
        {
            case ButtonAction.Retry:
                StateManager.Instance.OnRestartGame();
                break;
        }
    }
}