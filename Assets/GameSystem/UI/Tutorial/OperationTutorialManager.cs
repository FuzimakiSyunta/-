using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperationTutorialManager : MonoBehaviour
{
    private GameManager gameManagerScript; // GameManagerのスクリプトを参照するための変数
    public GameObject gameManager; // Inspectorで設定するGameManagerオブジェクト

    public bool isOperationTutorial = false; // チュートリアルがアクティブかどうかを示すフラグ

    public float TutorialShowTime = 0.0f; // チュートリアルの表示時間を管理する変数

    public GameObject skipImage; // スキップ用のUIイメージ
    public bool isSkip = false; // スキップフラグ

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = gameManager.GetComponent<GameManager>();
        skipImage.SetActive(false); // 初期状態ではスキップ用のUIイメージを非表示にする
        isSkip = false; // スキップフラグを初期化
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManagerScript.IsGameStart()&& TutorialShowTime <= 25.0f&&!isSkip) 
        {
            isOperationTutorial = true; // ゲーム開始時にチュートリアルを有効化
        }else
        {
            isOperationTutorial = false; // ゲーム開始後はチュートリアルを無効化
        }
        if ((Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown("joystick button 2")) && isOperationTutorial)
        {
            isSkip = true; // Eキーまたはジョイスティックのボタン2が押されたらスキップフラグを有効化
        }

        if (isOperationTutorial)
        {
            TutorialShowTime += Time.deltaTime; // チュートリアルの表示時間を更新
            skipImage.SetActive(true); // スキップ用のUIイメージを表示する
        }
        else
        {
            skipImage.SetActive(false); // チュートリアルが無効化されたらスキップ用のUIイメージを非表示にする
        }

        if (TutorialShowTime >= 25.0f)
        {
            EndOperationTutorial(); // チュートリアルの表示時間が25秒を超えたら終了
            gameManagerScript.GameStart(); // ゲームを開始
        }

    }

    public bool IsOperationTutorial()
    {
        return isOperationTutorial;
    }
    public void EndOperationTutorial()
    {
        isOperationTutorial = false; // チュートリアルを終了
        Debug.Log("操作チュートリアルが終了しました。");
    }
    public float GetTutorialShowTime()
    {
        return TutorialShowTime; // チュートリアルの表示時間を返す
    }
}
