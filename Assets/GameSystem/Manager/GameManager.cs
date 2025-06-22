
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
    [SerializeField] private HealEnergyManager healEnergyManager;
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
        AllIUi();
    }

    void OffSelect()
    {
        if (isSelectorOpened == false)
        {
            // タイトル画面でスペースキーまたはジョイスティックのボタン0が押されたらセレクトを開く
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 0"))
            {
                isSelectorOpened = true;
                titleText.SetActive(false);
                StartButtonImage.SetActive(false);
                GameStartFlag = false;
            }
        }
    }
    //UI
    void AllIUi()
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
    //ゲームオーバーフラグを立てる
    public void GameOverStart()
    {
        GameOverFlag = true;
        gameOverText.SetActive(true);
    }
    //ゲームオーバーフラグを取得
    public bool IsGameOver()
    {
        return GameOverFlag;
    }
    //ゲームクリアフラグを立てる
    public void GameClearStart()
    {
        GameClearFlag = true;
        gameClearText.SetActive(true);
    }
    //ゲームクリアフラグを取得
    public bool IsGameClear()
    {
        return GameClearFlag;
    }
    //ゲーム開始フラグを立てる
    public void GameStart()
    {
        GameStartFlag = true;
    }
    //ゲーム開始フラグを取得
    public bool IsGameStart()
    {
        return GameStartFlag;
    }
    //セレクトを開く
    public bool IsOpenSelector()
    {
        return isSelectorOpened;
    }
}
