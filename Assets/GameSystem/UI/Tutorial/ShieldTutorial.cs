
using UnityEngine;

public class ShieldTutorial : MonoBehaviour
{
    public GameObject ShieldTutorialImage;

    public GameObject operationTutorialManager;
    private OperationTutorialManager OperationTutorialManagerScript;

    public GameObject hoverTutorial; // ← HoverTutorial を参照
    private HoverTutorial hoverTutorialScript;

    private EnergyManager energyManagerScript; // EnergyManager を参照
    public GameObject energyManager; // Inspectorで設定するEnergyManagerオブジェクト

    void Start()
    {
        OperationTutorialManagerScript = operationTutorialManager.GetComponent<OperationTutorialManager>();
        hoverTutorialScript = hoverTutorial.GetComponent<HoverTutorial>();
        energyManagerScript = energyManager.GetComponent<EnergyManager>();
        if (ShieldTutorialImage != null)
        {
            ShieldTutorialImage.SetActive(false);
        }
    }

    void Update()
    {
        float tutorialShowTime = OperationTutorialManagerScript.GetTutorialShowTime();// 操作チュートリアルの表示時間を取得

        // Hover チュートリアルが完了したら表示
        if (OperationTutorialManagerScript.IsOperationTutorial() && tutorialShowTime >= 24.0f && tutorialShowTime <= 31.0f)
        {
            ShowShieldTutorial();
        }
        else
        {
            HideShieldTutorial();
        }
    }

    public void ShowShieldTutorial()
    {
        if (ShieldTutorialImage != null)
        {
            ShieldTutorialImage.SetActive(true);
            OperationTutorialManagerScript.EndOperationTutorial();// 操作チュートリアルを終了
            energyManagerScript.AddBatteryEnergy();
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
