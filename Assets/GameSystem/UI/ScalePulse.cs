using System.Collections;
using UnityEngine;

public class ScalePulse : MonoBehaviour
{
    public float scaleFactor = 1.5f; // Šg‘å”{—¦
    public float duration = 0.3f;   // Šg‘åEk¬‚É‚©‚©‚éŠÔ
    private Vector3 originalScale;// Œ³‚ÌƒXƒP[ƒ‹
    private PlayerStatus playerStatus;
    public GameObject player;

    void Start()
    {
        originalScale = transform.localScale;
        playerStatus = player.GetComponent<PlayerStatus>();
    }

    void Update()
    {
        if (playerStatus.IsHeal())
        {
            StartCoroutine(ScaleObject());
        }
    }

    IEnumerator ScaleObject()
    {
        // Šg‘å
        yield return StartCoroutine(ScaleTo(originalScale * scaleFactor, duration));
        // k¬
        yield return StartCoroutine(ScaleTo(originalScale, duration));
    }

    IEnumerator ScaleTo(Vector3 targetScale, float time)
    {
        Vector3 startScale = transform.localScale;
        float elapsedTime = 0f;
        // Šg‘åEk¬‚ÌŠÔ‚ÌŠÔ‚ğŒv‘ª
        while (elapsedTime < time)
        {
            transform.localScale = Vector3.Lerp(startScale, targetScale, elapsedTime / time);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localScale = targetScale;
    }
}