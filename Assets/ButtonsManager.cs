using System.Collections.Generic;
using UnityEngine;

public class ButtonsManager : MonoBehaviour
{
    [SerializeField] private List<InteractiveObject> _buttonsMap;

    private void Awake()
    {
        foreach (var buttonInfo in _buttonsMap)
        {
            buttonInfo.Setup();
        }
    }
}
