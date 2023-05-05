public class ButtonManager : SingletonBase<ButtonManager>
{
    public enum ButtonAction
    {
        Retry
    }

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
