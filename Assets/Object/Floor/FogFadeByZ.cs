using UnityEngine;

public class FogFadeByZ : MonoBehaviour
{
    private GameManager gameManagerScript; // GameManagerのスクリプト参照
    public GameObject gameManager; // GameManagerオブジェクト

    [SerializeField] private Renderer[] targetRenderers;  // 対象オブジェクトのRenderer
    [SerializeField] private float maxAlpha = 0.5f;       // 最大透明度（中央付近）
    [SerializeField] private float visibleRangeZ;   // 表示範囲Z（±）

    void Start()
    {
        // GameManagerのスクリプトを取得
        gameManagerScript = gameManager.GetComponent<GameManager>();
    }

    private void Update()
    {
        if(gameManagerScript.IsOpenSelector())
        {
            visibleRangeZ = 100.0f; // セレクター画面が開かれている場合、表示範囲を100に設定
            foreach (Renderer rend in targetRenderers)
            {
                if (rend == null) continue;

                float z = rend.transform.position.z;
                float absZ = Mathf.Abs(z);
                float alpha = 0f;

                if (absZ <= visibleRangeZ)
                {
                    float normalized = 1f - (absZ / visibleRangeZ); // 中心で1、端で0
                    alpha = normalized * maxAlpha;
                }

                // マテリアルのColor.a を変更（マテリアルは透明対応している必要あり）
                Color color = rend.material.color;
                color.a = alpha;
                rend.material.color = color;
            }
        }else
        {
            visibleRangeZ = 150.0f; // セレクター画面が閉じられた場合、表示範囲を150に設定
        }
    }   
}
