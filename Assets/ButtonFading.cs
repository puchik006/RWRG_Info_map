using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ButtonFading : MonoBehaviour
{
    [SerializeField] private Image imageToFadeOut;
    [SerializeField] private Image imageToFadeIn;
    [SerializeField] private float fadeDuration = 1.0f;

    private void Start()
    {
        // Ensure the first image is visible, and the second image is not
        imageToFadeOut.gameObject.SetActive(true);
        imageToFadeIn.gameObject.SetActive(false);
    }

    public void OnButtonPressed()
    {
        StartCoroutine(FadeOutAndIn());
    }

    private IEnumerator FadeOutAndIn()
    {
        yield return FadeOut();
        yield return FadeIn();
    }

    private IEnumerator FadeOut()
    {
        float elapsedTime = 0f;
        Color startColor = imageToFadeOut.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 0f);

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / fadeDuration);
            imageToFadeOut.color = Color.Lerp(startColor, endColor, t);
            yield return null;
        }

        // Deactivate the first image after fading out
        imageToFadeOut.gameObject.SetActive(false);
    }

    private IEnumerator FadeIn()
    {
        imageToFadeIn.gameObject.SetActive(true);
        float elapsedTime = 0f;
        Color startColor = new Color(1f, 1f, 1f, 0f);
        Color endColor = new Color(1f, 1f, 1f, 1f);

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / fadeDuration);
            imageToFadeIn.color = Color.Lerp(startColor, endColor, t);
            yield return null;
        }

        // Ensure the second image's alpha is fully set to 1 after fading in
        imageToFadeIn.color = new Color(endColor.r, endColor.g, endColor.b, 1f);
    }
}

