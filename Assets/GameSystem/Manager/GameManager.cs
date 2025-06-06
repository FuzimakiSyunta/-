
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static System.Net.Mime.MediaTypeNames;
using TMPro;

public class GameManager : MonoBehaviour
{
    //主要オブジェクト
    public GameObject UI;
    public GameObject gameOverText;
    public GameObject gameClearText;
    public GameObject titleText;
    public GameObject StartButtonImage;

    //セレクト
    private bool isSelectorOpened = false;

    //ゲームシステムフラグ
    public bool GameOverFlag = false;
    public bool GameClearFlag = false;
    public bool GameStartFlag = false;

    // 他マネージャー参照
    [SerializeField] private HealEnargyManager healEnargyManager;
    [SerializeField] private EnergyManager energyManager;
    [SerializeField] private WaveManager waveManager;

    void Start()
    {
        titleText.SetActive(true);
        StartButtonImage.SetActive(true);
    }

    void Update()
    {
        OffSelect();
        Allui();

        // エネルギーが0以下にならないように制御（EnargyManagerに移動済み）
        int energy = energyManager.GetBatteryEnargy();
    }

    void OffSelect()
    {
        if (isSelectorOpened == false)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 0"))
            {
                isSelectorOpened = true;
                titleText.SetActive(false);
                StartButtonImage.SetActive(false);
                GameStartFlag = false;
            }
        }
    }

    void Allui()
    {
        if (GameClearFlag == true)
        {
            UI.SetActive(false);
        }
        else
        {
            UI.SetActive(true);
        }
    }

    public void GameOverStart()
    {
        GameOverFlag = true;
        gameOverText.SetActive(true);
    }

    public bool IsGameOver()
    {
        return GameOverFlag;
    }

    public void GameClearStart()
    {
        GameClearFlag = true;
        gameClearText.SetActive(true);
    }

    public bool IsGameClear()
    {
        return GameClearFlag;
    }

    public void GameStart()
    {
        GameStartFlag = true;
    }

    public bool IsGameStart()
    {
        return GameStartFlag;
    }

    public bool IsOpenSelector()
    {
        return isSelectorOpened;
    }
}
