using UnityEngine;
using UnityEngine.UI;

public static class ZoomUtility
{
    public static void ZoomIn(this Image image, float zoomStep, float maxZoom)
    {
        Vector3 scale = image.transform.localScale;
        scale *= 1 + zoomStep;
        scale = Vector3.Min(scale, new Vector3(maxZoom, maxZoom, 1.0f));
        image.transform.localScale = scale;
    }

    public static void ZoomOut(this Image image, float zoomStep, float minZoom)
    {
        Vector3 scale = image.transform.localScale;
        scale /= 1 + zoomStep;
        scale = Vector3.Max(scale, new Vector3(minZoom, minZoom, 1.0f));
        image.transform.localScale = scale;
    }

    public static void ResetZoom(this Image image, float originalScale)
    {
        image.transform.localScale = new Vector3(originalScale, originalScale, 1.0f);
    }
}

