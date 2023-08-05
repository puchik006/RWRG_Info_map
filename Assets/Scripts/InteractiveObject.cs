using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class InteractiveObject
{
    [SerializeField] private Button _button;
    [SerializeField] private bool _isActiveAfterClick = false;
    [SerializeField] private List<GameObject> _gameObjectsActivation;

    public void Setup()
    {
        if (_button != null)
        {
            _button.onClick.AddListener(OnButtonClick);
        }
    }

    private void OnButtonClick()
    {
        foreach (var gameObject in _gameObjectsActivation)
        {
            gameObject.SetActive(_isActiveAfterClick);
        }
    }
}
