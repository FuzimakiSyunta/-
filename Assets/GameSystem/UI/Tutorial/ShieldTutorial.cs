
using UnityEngine;

public class ShieldTutorial : MonoBehaviour
{
    public GameObject ShieldTutorialImage;

    public GameObject operationTutorialManager;
    private OperationTutorialManager OperationTutorialManagerScript;

    public GameObject hoverTutorial; // ← HoverTutorial を参照
    private HoverTutorial hoverTutorialScript;

    void Start()
    {
        OperationTutorialManagerScript = operationTutorialManager.GetComponent<OperationTutorialManager>();
        hoverTutorialScript = hoverTutorial.GetComponent<HoverTutorial>();
        if (ShieldTutorialImage != null)
        {
            ShieldTutorialImage.SetActive(false);
        }
    }

    void Update()
    {
        float tutorialShowTime = OperationTutorialManagerScript.GetTutorialShowTime();// 操作チュートリアルの表示時間を取得

        // Hover チュートリアルが完了したら表示
        if (OperationTutorialManagerScript.IsOperationTutorial() && tutorialShowTime >= 18.0f && tutorialShowTime <= 23.0f)
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
