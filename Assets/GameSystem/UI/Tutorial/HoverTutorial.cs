
using UnityEngine;

public class HoverTutorial : MonoBehaviour
{
    public GameObject hoverTutorialImage;

    public GameObject moveTutorial; // ← MoveTutorial を参照
    private MoveTutorial moveTutorialScript;

    private bool isHoverTutorialActive = false;

    private OperationTutorialManager operationTutorialManagerScript;
    public GameObject operationTutorialManager; // Inspectorで設定するOperationTutorialManagerオブジェクト

    void Start()
    {
        moveTutorialScript = moveTutorial.GetComponent<MoveTutorial>();
        operationTutorialManagerScript = operationTutorialManager.GetComponent<OperationTutorialManager>();
        if (hoverTutorialImage != null)
        {
            hoverTutorialImage.SetActive(false);
        }
    }

    void Update()
    {
        // 操作チュートリアルの表示時間を取得
        float tutorialShowTime = operationTutorialManagerScript.GetTutorialShowTime();
        // Move チュートリアルが終わってから表示
        if (operationTutorialManagerScript.IsOperationTutorial() && tutorialShowTime >= 16.0f && tutorialShowTime <= 23.0f)
        {
            ShowHoverTutorial();
        }else
        {
            HideHoverTutorial();
        }
    }

    public void ShowHoverTutorial()
    {
        if (!isHoverTutorialActive && hoverTutorialImage != null)
        {
            hoverTutorialImage.SetActive(true);
            isHoverTutorialActive = true;
        }
    }

    public bool IsHoverTutorialActive()
    {
        return isHoverTutorialActive;
    }

    public void HideHoverTutorial()
    {
        if (hoverTutorialImage != null)
        {
            hoverTutorialImage.SetActive(false);
            isHoverTutorialActive = false;
        }
    }
}
