using UnityEngine;
using System.Collections;

public class BlinkEffect : MonoBehaviour
{
    public Renderer targetRenderer;
    public Material flashMaterial; // ← Inspectorで設定
    public float flashDuration = 0.1f;

    private Material originalMaterial;

    void Start()
    {
        if (targetRenderer == null)
            targetRenderer = GetComponent<Renderer>();

        // マテリアルのインスタンスを保存
        originalMaterial = targetRenderer.material;
    }

    public void Flash()
    {
        StartCoroutine(FlashRoutine());
    }

    IEnumerator FlashRoutine()
    {
        targetRenderer.material = flashMaterial;
        yield return new WaitForSeconds(flashDuration);
        targetRenderer.material = originalMaterial;
    }
}
