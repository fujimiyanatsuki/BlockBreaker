using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : SingletonBase<PanelManager>
{
    public GameObject GameOverDialog;
    public GameObject ClearDialog;

    public void ActiveGameOverPanel()
    {
        GameOverDialog.SetActive(true);
    }     

    public void ActiveClearPanel()
    {
        ClearDialog.SetActive(true);
    } 

     public void HidePanel()
    {
        ClearDialog.SetActive(false);
        GameOverDialog.SetActive(false);
    }    
}


