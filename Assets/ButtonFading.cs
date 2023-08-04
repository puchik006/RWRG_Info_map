using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonFading : MonoBehaviour, IPointerDownHandler
{
    private Button _button;
    [SerializeField] private Graphic _handImage;
    [SerializeField] private Graphic _handText;
    [SerializeField] private Graphic _map; 
    [SerializeField] private float _fadeDuration = 1.0f;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _button.enabled = false;
        StartCoroutine(_handImage.FadeOut(_fadeDuration));
        StartCoroutine(_handText.FadeOut(_fadeDuration, MapFadeIn));
    }

    private void MapFadeIn()
    {
        StartCoroutine(_map.FadeIn(_fadeDuration));
    }
}
