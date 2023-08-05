using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonFading : MonoBehaviour
{
    private Button _button;
    [SerializeField] private bool _leaveButtonActive = true;
    [SerializeField] private List<Graphic> _objectsToFadeOut;
    [SerializeField] private List<Graphic> _objectsToFadeIn;
    [SerializeField] private float _fadeDuration = 1.0f;
    [SerializeField] private float _pauseBeforeFadeIn = 1.0f;

    private void Awake()
    {
        InactivityManager.ApplicationReseted += OnAplicationReseted;
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
         _button.enabled = _leaveButtonActive;
        _objectsToFadeOut.ForEach(e => StartCoroutine(e.FadeOut(_fadeDuration)));
        _objectsToFadeIn.ForEach(e => StartCoroutine(e.FadeIn(_fadeDuration,pauseOnStart: _pauseBeforeFadeIn)));
    }

    private void OnAplicationReseted()
    {
        _button.enabled = true;
        _objectsToFadeOut.ForEach(e => e.TransparecyOff());
        _objectsToFadeIn.ForEach(e => e.TransparecyOn());
    }
}

