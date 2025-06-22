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
            energyTextCancvas.SetActive(false); // チュートリアル開始時は非表示
        }
    }

    void Update()
    {
        if (!OperationTutorialManagerScript.IsOperationTutorial())
        {
            HideShieldTutorial();
            return;
        }

        float tutorialShowTime = OperationTutorialManagerScript.GetTutorialShowTime();

        // 一度だけ表示
        if (!hasShownShieldTutorial && tutorialShowTime >= 24.0f)
        {
            ShowShieldTutorial();
            hasShownShieldTutorial = true;
        }

        // 31秒でチュートリアル終了・UI非表示・ゲーム開始
        if (tutorialShowTime >= 31.0f && !hasCompletedTutorial)
        {
            hasCompletedTutorial = true;
            HideShieldTutorial();
            OperationTutorialManagerScript.CompleteTutorial();
        }
        if(gameManagerScript.IsGameOver()||gameManagerScript.IsGameClear())
        {
            energyTextCancvas.SetActive(false); // ゲームオーバーまたはクリア時にエネルギーテキストを非表示
        }
    }

    public void ShowShieldTutorial()
    {
        energyManagerScript.AddBatteryEnergy(); // エネルギーを加算
        if (ShieldTutorialImage != null)
        {
            ShieldTutorialImage.SetActive(true);
        }
        if (energyTextCancvas != null)
        {
            energyTextCancvas.SetActive(true); // チュートリアル開始時にエネルギーテキストを表示
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
