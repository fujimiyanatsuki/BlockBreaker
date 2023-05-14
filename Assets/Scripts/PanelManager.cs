using UnityEngine;
using UnityEngine.UI;

public class PanelManager : SingletonBase<PanelManager>
{
    /// <summary>
    /// Panel
    /// </summary>
    public GameObject Panel;
    /// <summary>
    /// ゲームクリア時の画像
    /// </summary>
    public Image CrearImage;
    /// <summary>
    /// ゲームオーバー時の画像
    /// </summary>
    public Image GameOverImage;

    /// <summary>
    /// リトライボタン
    /// </summary>
    public GameObject RetryButton;

    /// <summary>
    /// Panelに関する初期処理
    /// </summary>
    public void Initialize()
    {
        SetCanvas();
    }

    /// <summary>
    /// ダイアログを表示
    /// </summary>
    public void SetCanvas()
    {
        Panel.GetComponent<Image>().color = GetBackGroundColor();
        SetRetryButton();
        SetDialogImage();
        Panel.SetActive(true);
    }

    /// <summary>
    /// リトライボタンの表示を制御
    /// </summary>
    private void SetRetryButton()
    {
        switch (StateManager.Instance.CurrentState)
        {
            case StateManager.GameState.GameClear:
            case StateManager.GameState.GameOver:
                RetryButton.SetActive(true);
                break;
            case StateManager.GameState.ReStart:
            case StateManager.GameState.Playing:
                RetryButton.SetActive(false);
                break;
        }
    }

    /// <summary>
    /// Panelの色を取得
    /// </summary>
    /// <returns></returns>
    private Color GetBackGroundColor()
    {
        switch (StateManager.Instance.CurrentState)
        {
            // 画面全体に青色の背景を重ねる
            case StateManager.GameState.GameClear:
                return new Color(0.1f, 0.2f, 0.5f, 0.5f);
            // 画面全体に赤色の背景を重ねる
            case StateManager.GameState.GameOver:
                return new Color(0.5f, 0, 0, 0.5f);
        }
        return new Color(0, 0, 0, 0);
    }

    /// <summary>
    /// Panelの画像をセット
    /// </summary>
    private void SetDialogImage()
    {
        switch (StateManager.Instance.CurrentState)
        {
            case StateManager.GameState.GameClear:
                GameOverImage.enabled = false;
                CrearImage.enabled = true;
                break;
            case StateManager.GameState.GameOver:
                CrearImage.enabled = false;
                GameOverImage.enabled = true;
                break;
            case StateManager.GameState.ReStart:
            case StateManager.GameState.Playing:
                CrearImage.enabled = false;
                GameOverImage.enabled = false;
                break;
        }
    }
}