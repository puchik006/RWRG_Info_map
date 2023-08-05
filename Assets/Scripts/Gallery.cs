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
        InfoPointHandler.GalleryOpened += OnGalleryOpened;

        _leftArrowButton.onClick.AddListener(ShowPreviousImage);
        _rightArrowButton.onClick.AddListener(ShowNextImage);
        _closeButton.onClick.AddListener(CloseGalleryView);

        CloseGalleryView();
    }

    private void OnGalleryOpened(List<Sprite> images)
    {
        _images = images;
        currentIndex = default;
        OpenGalleryView();
        ShowImageAtIndex(currentIndex);
    }

    private void OpenGalleryView()
    {
        _imageView.gameObject.SetActive(true);
        _leftArrowButton.gameObject.SetActive(true);
        _rightArrowButton.gameObject.SetActive(true);
        _closeButton.gameObject.SetActive(true);
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

    private void CloseGalleryView()
    {
        _imageView.gameObject.SetActive(false);
        _leftArrowButton.gameObject.SetActive(false);
        _rightArrowButton.gameObject.SetActive(false);
        _closeButton.gameObject.SetActive(false);
    }
}