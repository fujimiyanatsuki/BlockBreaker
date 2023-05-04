using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBase<GameManager>
{
    public GameObject Ball;

    private int currentBlockNum;
    public int maxBlockNum = 168;

    void Start()
    {
        currentBlockNum = maxBlockNum;
    }

    public void GameOver()
    {
        Destroy(Ball);
        PanelManager.Instance.ActiveGameOverPanel();
    }

    public void BlockBreak()
    {
        currentBlockNum--;
        if (currentBlockNum == 0)
        {
            Destroy(Ball);
            PanelManager.Instance.ActiveClearPanel();
        }
    }
}
