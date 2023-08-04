using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ZoomController : MonoBehaviour, IPointerDownHandler
{
    private Image _imageToZoom;
    [SerializeField] private Button _zoomInButton;
    [SerializeField] private Button _zoomOutButton;
    [SerializeField] private Button _resetZoomButton;

    private float _originalScale;
    private float _zoomStep = 0.1f;
    private float _maxZoom = 1.5f;
    private float _minZoom = 0.5f;

    private Dictionary<GameObject, Action> _buttonToAction = new Dictionary<GameObject, Action>();

    private void Awake()
    {
        _imageToZoom = GetComponent<Image>();
    }

    private void Start()
    {
        _buttonToAction.Add(_zoomInButton.gameObject, () => _imageToZoom.ZoomIn(_zoomStep, _maxZoom));
        _buttonToAction.Add(_zoomOutButton.gameObject, () => _imageToZoom.ZoomOut(_zoomStep, _minZoom));
        _buttonToAction.Add(_resetZoomButton.gameObject, () => _imageToZoom.ResetZoom(_originalScale));

        _originalScale = _imageToZoom.transform.localScale.x;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        GameObject pressedObject = eventData.pointerPress;

        if (_buttonToAction.TryGetValue(pressedObject, out Action action))
        {
            action.Invoke();
        }
    }
}

public static class ZoomUtility
{
    public static void ZoomIn(this Image image, float zoomSpeed, float maxZoom)
    {
        Vector3 scale = image.transform.localScale;
        scale *= 1 + zoomSpeed;
        scale = Vector3.Min(scale, new Vector3(maxZoom, maxZoom, 1.0f));
        image.transform.localScale = scale;
    }

    public static void ZoomOut(this Image image, float zoomSpeed, float minZoom)
    {
        Vector3 scale = image.transform.localScale;
        scale /= 1 + zoomSpeed;
        scale = Vector3.Max(scale, new Vector3(minZoom, minZoom, 1.0f));
        image.transform.localScale = scale;
    }

    public static void ResetZoom(this Image image, float originalScale)
    {
        image.transform.localScale = new Vector3(originalScale, originalScale, 1.0f);
    }
}

