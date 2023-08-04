using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InfoPointHandler: MonoBehaviour
{
    [SerializeField] private InfoPointCard _card;
    [SerializeField] private Image _mainmage;
    [SerializeField] private TMP_Text _discription;
    [SerializeField] private Button _openGalleryButton;

    public static event Action<List<Sprite>> GalleryOpened;

    private void Awake()
    {
        _mainmage.sprite = _card.Images[default];
        _discription.text = _card.Discription;
        _openGalleryButton.onClick.AddListener(OpenGallery);
    }

    private void OpenGallery()
    {
        GalleryOpened?.Invoke(_card.Images);
    }
}
