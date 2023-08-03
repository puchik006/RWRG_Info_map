using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public static class GraphicExtensions
{
    public static IEnumerator FadeOut(this Graphic graphicToFadeOut, float fadeDuration)
    {
        float elapsedTime = 0f;
        Color startColor = graphicToFadeOut.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 0f);

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / fadeDuration);
            graphicToFadeOut.color = Color.Lerp(startColor, endColor, t);
            yield return null;
        }

        graphicToFadeOut.gameObject.SetActive(false);
    }

    public static IEnumerator FadeIn(this Graphic graphicToFadeIn, float fadeDuration)
    {
        graphicToFadeIn.gameObject.SetActive(true);
        float elapsedTime = 0f;
        Color startColor = new Color(1f, 1f, 1f, 0f);
        Color endColor = new Color(1f, 1f, 1f, 1f);

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / fadeDuration);
            graphicToFadeIn.color = Color.Lerp(startColor, endColor, t);
            yield return null;
        }

        graphicToFadeIn.color = new Color(endColor.r, endColor.g, endColor.b, 1f);
    }
}
