using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public static class GraphicExtensions
{
    public static IEnumerator FadeOut(this Graphic graphicToFadeOut, float fadeDuration, Action callbackAction = null)
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
        callbackAction?.Invoke();
    }

    public static IEnumerator FadeIn(this Graphic graphicToFadeIn, float fadeDuration, Action callbackAction = null)
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
        callbackAction?.Invoke();
    }

    public static IEnumerator Pulse(this Graphic graphicToPulse, float pulseSpeed, float pulseAmplitude)
    {
        Vector3 originalScale = graphicToPulse.transform.localScale;
        float sinTime = 0f;

        while (true)
        {
            sinTime += Time.deltaTime;
            float newScale = originalScale.x + Mathf.Sin(sinTime * pulseSpeed) * pulseAmplitude;
            graphicToPulse.transform.localScale = new Vector3(newScale, newScale, 1f);
            yield return null;
        }
    }
}
