
using UnityEngine;

public class MoveTutorial : MonoBehaviour
{
    public GameObject moveTutorialImage;

    public GameObject operationTutorialManager;
    private OperationTutorialManager operationTutorialManagerScript;

    public GameObject shotTutorial; // ← ShotTutorial を参照
    private ShotTutorial shotTutorialScript;

    private bool isMoveTutorialActive = false;

    void Start()
    {
        operationTutorialManagerScript = operationTutorialManager.GetComponent<OperationTutorialManager>();
        shotTutorialScript = shotTutorial.GetComponent<ShotTutorial>();
        if (moveTutorialImage != null)
        {
            moveTutorialImage.SetActive(false);
        }
    }

    void Update()
    {
        // 操作チュートリアルの表示時間を取得
        float tutorialShowTime = operationTutorialManagerScript.GetTutorialShowTime();
        // Shot チュートリアルが表示された後に Move を表示
        if (operationTutorialManagerScript.IsOperationTutorial() && tutorialShowTime >= 6.0f && tutorialShowTime <= 11.0f)
        {
            ShowMoveTutorial();
        }
        else
        {
            HideMoveTutorial();
        }
    }

    public void ShowMoveTutorial()
    {
        if (!isMoveTutorialActive && moveTutorialImage != null)
        {
            moveTutorialImage.SetActive(true);
            isMoveTutorialActive = true;
        }
    }

    public bool IsMoveTutorialActive()
    {
        return isMoveTutorialActive;
    }

    public void HideMoveTutorial()
    {
        if (moveTutorialImage != null)
        {
            moveTutorialImage.SetActive(false);
            isMoveTutorialActive = false;
        }
    }
}
