using UnityEngine;


public class OperationTutorialManager : MonoBehaviour
{
    private GameManager gameManagerScript;
    public GameObject gameManager;

    public bool isOperationTutorial = false;
    public float TutorialShowTime = 0.0f;

    public GameObject skipImage;
    private bool hasShownSkipUI = false;

    public GameObject energyManager;
    private EnergyManager energyManagerScript;

    private bool isSkippable = false;
    private bool hasCompleted = false;

    void Start()
    {
        gameManagerScript = gameManager.GetComponent<GameManager>();
        energyManagerScript = energyManager.GetComponent<EnergyManager>();

        skipImage.SetActive(false);
        TutorialShowTime = 0f;
        hasShownSkipUI = false;
        hasCompleted = false;

        isOperationTutorial = false;
        isSkippable = false; // ← 初回前提でfalse
        Debug.Log("初回起動かどうか: " + (PlayerPrefs.GetInt("TutorialDone", 0) == 0));
    }

    void Update()
    {
        if (!isOperationTutorial) return;

        TutorialShowTime += Time.deltaTime;

        // スキップUI表示（2回目以降のみ）
        if (isSkippable && !hasShownSkipUI)
        {
            skipImage.SetActive(true);
            hasShownSkipUI = true;
        }
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.DeleteKey("TutorialDone");
            PlayerPrefs.Save();
            Debug.Log("TutorialDone をリセットしました（次回は初回として扱われます）");
        }
#endif

        // スキップ操作（2回目以降のみ）
        if (isSkippable && (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown("joystick button 1")))
        {
            Debug.Log("チュートリアルをスキップしました");
            CompleteTutorial();
        }
    }

    public void StartOperationTutorial()
    {
        isOperationTutorial = true;
        TutorialShowTime = 0f;
        hasShownSkipUI = false;
        skipImage.SetActive(false);

        // チュートリアル完了済みならスキップ可能にする
        isSkippable = PlayerPrefs.GetInt("TutorialDone", 0) == 1;

        Debug.Log("操作チュートリアルを開始しました（isSkippable: " + isSkippable + ")");
    }

    public void CompleteTutorial()
    {
        if (!isOperationTutorial || hasCompleted) return;

        isOperationTutorial = false;
        skipImage.SetActive(false);
        hasCompleted = true;

        energyManagerScript.ResetBattery();
        gameManagerScript.GameStart();

        // ※ここでは PlayerPrefs は書き込まない（シーン切り替え時に保存する）
        Debug.Log("チュートリアル終了 → ゲーム開始");
    }

    public bool IsOperationTutorial()
    {
        return isOperationTutorial;
    }

    public float GetTutorialShowTime()
    {
        return TutorialShowTime;
    }
}
