// using System.Collections;
// using UnityEngine;
// using UnityEngine.XR;

// public class FlashBangGPT : MonoBehaviour
// {
//     public float fadeDuration = 1f;
//     public float inhibitionDuration = 3f;

//     public void InhibitVision()
//     {
//         StartCoroutine(InhibitVisionCoroutine());
//     }

//     private IEnumerator InhibitVisionCoroutine()
//     {
//         // Fade in to white
//         yield return StartCoroutine(FlashWhite());

//         // Wait for the inhibition duration
//         yield return new WaitForSeconds(inhibitionDuration);

//         // Fade out from white
//         yield return StartCoroutine(FadeFromWhite());
//     }

//     private IEnumerator FlashWhite()
//     {
//         // float elapsedTime = 0f;
//         // while (elapsedTime < fadeDuration)
//         // {
//         //     elapsedTime += Time.deltaTime;
//         //     float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
//         //     SetVRScreenOverlayColor(alpha);
//         //     yield return null;
//         // }

//         SetVRScreenOverlayColor(1f);
//     }

//     private IEnumerator FadeFromWhite()
//     {
//         float elapsedTime = 0f;
//         while (elapsedTime < fadeDuration)
//         {
//             elapsedTime += Time.deltaTime;
//             float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
//             SetVRScreenOverlayColor(alpha);
//             yield return null;
//         }

//         SetVRScreenOverlayColor(0f);
//     }

//     private void SetVRScreenOverlayColor(float alpha)
//     {
//         var color = new Color(1f, 1f, 1f, alpha);
//         XRSettings.renderViewportScale = alpha;
//         // Set the color of the left and right eyes for VR
//         UnityEngine.XR.XRSettings.eyeTextureDesc.colorFormat = UnityEngine.Experimental.Rendering.GraphicsFormat.R8G8B8A8_UNorm;
//         UnityEngine.XR.XRSettings.eyeTextureDesc.sRGB = true;
//         UnityEngine.XR.XRSettings.eyeTextureDesc.dimension = UnityEngine.Rendering.TextureDimension.Tex2D;
//     }
// }


using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FlashBangGPT : MonoBehaviour
{
    public CanvasGroup whiteCanvasGroup;
    public float fadeDuration = 1f;
    public float fadeInDuration = 0.1f;
    public float inhibitionDuration = 3f;

    private void Start()
    {
        if (whiteCanvasGroup == null)
        {
            Debug.LogError("VisualInhibitor: whiteCanvasGroup is not set.");
        }
        SetCanvasGroupAlpha(0f);
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
            SetCanvasGroupAlpha(alpha);
            yield return null;
        }

        SetCanvasGroupAlpha(1f);
    }

    private IEnumerator FadeFromWhite()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            SetCanvasGroupAlpha(alpha);
            yield return null;
        }

        SetCanvasGroupAlpha(0f);
    }

    private void SetCanvasGroupAlpha(float alpha)
    {
        whiteCanvasGroup.alpha = alpha;
    }
}