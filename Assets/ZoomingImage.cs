using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ZoomingImage : MonoBehaviour
{
    private Image _imageToZoom;
    [SerializeField] private Button _zoomInButton;
    [SerializeField] private Button _zoomOutButton;
    [SerializeField] private Button _resetZoomButton;

    private float _originalScale;
    private float _zoomStep = 0.1f;
    private float _maxZoom = 1.5f; 
    private float _minZoom = 0.5f;

    private void Awake()
    {
        _imageToZoom = GetComponent<Image>();
    }

    private void Start()
    {
        _originalScale = _imageToZoom.transform.localScale.x;

        _zoomInButton.onClick.AddListener(() => _imageToZoom.ZoomIn(_zoomStep,_maxZoom));
        _zoomOutButton.onClick.AddListener(() => _imageToZoom.ZoomOut(_zoomStep, _minZoom));
        _resetZoomButton.onClick.AddListener(() => _imageToZoom.ResetZoom(_originalScale));
    }
}

