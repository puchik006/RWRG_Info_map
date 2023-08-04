using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gallery : MonoBehaviour
{
    private List<Sprite> _images;
    [SerializeField] private Image _imageView;
    [SerializeField] private Button _leftArrowButton;
    [SerializeField] private Button _rightArrowButton;
    [SerializeField] private Button _closeButton;
    private int currentIndex = 0;

    private void Awake()
    {
        InfoPointHandler.GalleryOpened += (List<Sprite> e) => _images = e;
    }

    private void Start()
    {
        _leftArrowButton.onClick.AddListener(ShowPreviousImage);
        _rightArrowButton.onClick.AddListener(ShowNextImage);
        _closeButton.onClick.AddListener(CloseGallery);

        ShowImageAtIndex(currentIndex);
    }

    private void ShowImageAtIndex(int index)
    {
        if (index >= 0 && index < _images.Count)
        {
            _imageView.sprite = _images[index];
        }
    }

    private void ShowPreviousImage()
    {
        currentIndex = (currentIndex - 1 + _images.Count) % _images.Count;
        ShowImageAtIndex(currentIndex);
    }

    private void ShowNextImage()
    {
        currentIndex = (currentIndex + 1) % _images.Count;
        ShowImageAtIndex(currentIndex);
    }

    private void CloseGallery()
    {
        gameObject.SetActive(false);
    }
}