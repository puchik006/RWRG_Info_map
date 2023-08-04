using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    [SerializeField] private Transform _gallery;

    private void Awake()
    {
        InfoPointHandler.GalleryOpened += (List<Sprite> e) => _gallery.gameObject.SetActive(true);
    }
}
