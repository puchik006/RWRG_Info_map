using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    [SerializeField] private GameObject _mainScreen;
    [SerializeField] private List<GameObject> _otherScreens;

    private void Awake()
    {
        InactivityManager.ApplicationReseted += ResetScreens;
    }

    private void ResetScreens()
    {
        _mainScreen.SetActive(true);
        _otherScreens.ForEach(e => e.SetActive(false));
    }
}
