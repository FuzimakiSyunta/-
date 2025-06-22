using UnityEngine;
using UnityEngine.UI;

public class FogTransparencyByZ : MonoBehaviour
{
    private GameManager gameManagerScript; // GameManagerのスクリプト参照
    public GameObject gameManager; // GameManagerオブジェクト

    [SerializeField] private Image[] fogImages;     // Fog Image配列
    [SerializeField] private float maxAlpha = 2.0f; // 中央での最大透明度
    [SerializeField] private float fadeZRange; // フェード距離のZ値

    void Start()
    {
        // GameManagerのスクリプトを取得
        gameManagerScript = gameManager.GetComponent<GameManager>();
    }

    private void Update()
    {
        if(gameManagerScript.IsOpenSelector())
        {
            fadeZRange= 100.0f; // セレクター画面が開かれている場合、フェード距離を85.8に設定
            foreach (Image fog in fogImages)
            {
                if (fog == null) continue;

                float z = fog.transform.position.z;

                // 中心に近いほど1、端に近いほど0
                float distanceFactor = 1f - Mathf.Clamp01(Mathf.Abs(z) / fadeZRange);

                // アルファを計算
                Color c = fog.color;
                c.a = distanceFactor * maxAlpha;
                fog.color = c;
            }
        }else
        {
            fadeZRange = 150.0f; // セレクター画面が閉じられた場合、フェード距離を246に設定
        }
        
    }
}
