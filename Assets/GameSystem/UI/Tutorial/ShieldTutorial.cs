using UnityEngine;

public class ShieldTutorial : MonoBehaviour
{
    public GameObject ShieldTutorialImage;

    public GameObject operationTutorialManager;
    private OperationTutorialManager OperationTutorialManagerScript;

    private GameManager gameManagerScript;
    public GameObject gameManager;

    private EnergyManager energyManagerScript;
    public GameObject energyManager;

    public GameObject hoverTutorial;
    private HoverTutorial hoverTutorialScript;

    private bool hasShownShieldTutorial = false;
    private bool hasCompletedTutorial = false;

    public GameObject energyTextCancvas;

    void Start()
    {
        OperationTutorialManagerScript = operationTutorialManager.GetComponent<OperationTutorialManager>();
        hoverTutorialScript = hoverTutorial.GetComponent<HoverTutorial>();
        energyManagerScript = energyManager.GetComponent<EnergyManager>();
        gameManagerScript = gameManager.GetComponent<GameManager>();

        if (ShieldTutorialImage != null)
        {
            ShieldTutorialImage.SetActive(false);
        }
        if (energyTextCancvas != null)
        {
            energyTextCancvas.SetActive(false); // 初期状態では非表示
        }
    }

    void Update()
    {
        float tutorialShowTime = OperationTutorialManagerScript.GetTutorialShowTime();

        // シールドチュートリアル表示条件
        if (OperationTutorialManagerScript.IsOperationTutorial())
        {
            if (!hasShownShieldTutorial && tutorialShowTime >= 24.0f)
            {
                ShowShieldTutorial();
                hasShownShieldTutorial = true;
            }

            if (tutorialShowTime >= 31.0f && !hasCompletedTutorial)
            {
                hasCompletedTutorial = true;
                HideShieldTutorial();
                OperationTutorialManagerScript.CompleteTutorial();
            }
        }

        // ✅ energyTextCanvas の表示制御（チュートリアル or ゲーム中のみ）
        bool showEnergyUI = OperationTutorialManagerScript.IsOperationTutorial() || gameManagerScript.IsGameStart();

        if (energyTextCancvas != null)
        {
            energyTextCancvas.SetActive(showEnergyUI);
        }
    }

    public void ShowShieldTutorial()
    {
        energyManagerScript.AddBatteryEnergy(); // エネルギー加算
        if (ShieldTutorialImage != null)
        {
            ShieldTutorialImage.SetActive(true);
        }
    }

    public void HideShieldTutorial()
    {
        if (ShieldTutorialImage != null)
        {
            ShieldTutorialImage.SetActive(false);
        }
    }
}
