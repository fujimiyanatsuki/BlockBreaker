using UnityEngine;

public class PanelManager : SingletonBase<PanelManager>
{
    /// <summary>
    /// ゲームオーバー時のダイアログ
    /// </summary>
    public GameObject GameOverDialog;

    /// <summary>
    /// ゲームクリア時のダイアログ
    /// </summary>
    public GameObject ClearDialog;

    /// <summary>
    /// ゲームオーバー時のダイアログを表示
    /// </summary>
    public void ActiveGameOverPanel()
    {
        GameOverDialog.SetActive(true);
    }

    /// <summary>
    /// ゲームクリア時のダイアログを表示
    /// </summary>
    public void ActiveClearPanel()
    {
        ClearDialog.SetActive(true);
    }

    /// <summary>
    /// すべてのダイアログを非表示
    /// </summary>
    public void HidePanel()
    {
        ClearDialog.SetActive(false);
        GameOverDialog.SetActive(false);
    }
}