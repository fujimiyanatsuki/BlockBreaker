using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject GameOverDialog;
    public GameObject ClearDialog;
    public GameObject ball;

    private int currentBlockNum;
    public int maxBlockNum = 168;

    public static GameManager Instance { get; private set; }

    void Start()
    {
        Instance = this;
        currentBlockNum = maxBlockNum;
    }

    void Update()
    {
        
    }

    public void GameOver()
    {
        Destroy(ball);
        GameOverDialog.SetActive(true);
    }

    public void BlockBreak()
    {
        currentBlockNum--;
        if (currentBlockNum == 0)
        {
            Destroy(ball);
            ClearDialog.SetActive(true);
        }
    }
}
