using UnityEngine;
using UnityEngine.UI;

public class ButtonFading : MonoBehaviour
{
    [SerializeField] private Graphic _handImage;
    [SerializeField] private Graphic _handText;
    [SerializeField] private Graphic _map; 
    [SerializeField] private float _fadeDuration = 1.0f;

    public void OnButtonPressed()
    {
        StartCoroutine(_handImage.FadeOut(_fadeDuration));
        StartCoroutine(_handText.FadeIn(_fadeDuration));
        StartCoroutine(_map.FadeOut(_fadeDuration));
    }
}
