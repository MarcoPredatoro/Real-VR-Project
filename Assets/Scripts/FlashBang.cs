using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FlashBang : MonoBehaviour
{
    //public CanvasGroup whiteCanvasGroup;
    public Image whiteImage;
    public float fadeDuration = 1f;
    public float fadeInDuration = 0.1f;
    public float inhibitionDuration = 3f;

    private void Start()
    {
        if (whiteImage == null)
        {
            Debug.LogError("VisualInhibitor: whiteCanvasGroup is not set.");
        }
        //SetCanvasGroupAlpha(0f);
        SetWhiteImageAlpha(0f);
    }

    public void InhibitVision()
    {
        StartCoroutine(InhibitVisionCoroutine());
    }

    private IEnumerator InhibitVisionCoroutine()
    {
        // Fade in to white
        yield return StartCoroutine(FadeToWhite());

        // Wait for the inhibition duration
        yield return new WaitForSeconds(inhibitionDuration);

        // Fade out from white
        yield return StartCoroutine(FadeFromWhite());
    }

    private IEnumerator FadeToWhite()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeInDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeInDuration);
            SetWhiteImageAlpha(alpha);
            yield return null;
        }

        SetWhiteImageAlpha(1f);
    }

    private IEnumerator FadeFromWhite()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            SetWhiteImageAlpha(alpha);
            yield return null;
        }

       SetWhiteImageAlpha(0f);
    }

    // private void SetCanvasGroupAlpha(float alpha)
    // {
    //     whiteCanvasGroup.alpha = alpha;
    // }

    private void SetWhiteImageAlpha(float alpha)
    {
        Color color = whiteImage.color;
        color.a = alpha;
        whiteImage.color = color;
    }
}