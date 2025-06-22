using TMPro;
using UnityEngine;

public class EnergyTextScaler : MonoBehaviour
{
    public TextMeshProUGUI energyText; // TextMeshProテキスト
    private GameManager gameManagerScript;
    public GameObject gameManager;
    private EnergyManager energyManagerScript;
    public GameObject energyManager; // EnergyManagerのスクリプト

    private int previousEnergy = 0;
    private Vector3 originalScale;
    private float scaleDuration = 0.2f;
    private float scaleTimer = 0f;
    private bool isScaling = false;

    void Start()
    {
        gameManagerScript = gameManager.GetComponent<GameManager>();
        energyManagerScript = energyManager.GetComponent<EnergyManager>();
        originalScale = energyText.transform.localScale;
        previousEnergy = energyManagerScript.GetBatteryEnergy();
    }

    void Update()
    {
        int currentEnergy = energyManagerScript.GetBatteryEnergy();
        energyText.text = currentEnergy.ToString();

        // 数値が増えた時だけ拡大演出
        if (currentEnergy > previousEnergy)
        {
            isScaling = true;
            scaleTimer = 0f;
        }

        // 拡大縮小のアニメーション
        if (isScaling)
        {
            scaleTimer += Time.deltaTime;
            float t = scaleTimer / scaleDuration;

            if (t < 0.5f)
            {
                // 拡大
                energyText.transform.localScale = Vector3.Lerp(originalScale, originalScale * 1.4f, t * 2f);
            }
            else if (t < 1f)
            {
                // 縮小
                energyText.transform.localScale = Vector3.Lerp(originalScale * 1.4f, originalScale, (t - 0.5f) * 2f);
            }
            else
            {
                // 終了
                energyText.transform.localScale = originalScale;
                isScaling = false;
            }
        }

        previousEnergy = currentEnergy;
    }
}
