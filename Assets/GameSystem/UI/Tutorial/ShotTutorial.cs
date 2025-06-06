
using UnityEngine;

public class ShotTutorial : MonoBehaviour
{
    public GameObject shotTutorialImage;

    private bool isShotTutorialActive = false;

    // OperationTutorialManager の参照
    private OperationTutorialManager operationTutorialManagerScript;
    public GameObject operationTutorialManager;

    void Start()
    {
        if (shotTutorialImage != null)
        {
            shotTutorialImage.SetActive(false);
        }
        operationTutorialManagerScript = operationTutorialManager.GetComponent<OperationTutorialManager>();
    }

    void Update()
    {
        // 操作チュートリアルの表示時間を取得
        float tutorialShowTime = operationTutorialManagerScript.GetTutorialShowTime();
        if (operationTutorialManagerScript.IsOperationTutorial()&&tutorialShowTime <=5.0f)
        {
            ShowShotTutorial();
        }
        else
        {
            HideShotTutorial();
        }
       
    }

    // Shot チュートリアルを表示してフラグを立てる
    public void ShowShotTutorial()
    {
        if (!isShotTutorialActive && shotTutorialImage != null)
        {
            shotTutorialImage.SetActive(true);
            isShotTutorialActive = true;
        }
    }

    // Move チュートリアルから参照されるフラグ
    public bool IsShotTutorialActive()
    {
        return isShotTutorialActive;
    }

    // Shot チュートリアルを非表示にする
    public void HideShotTutorial()
    {
        if (shotTutorialImage != null)
        {
            shotTutorialImage.SetActive(false);
            isShotTutorialActive = false;
        }
    }
}
