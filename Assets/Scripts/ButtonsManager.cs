using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsManager : MonoBehaviour
{
    [SerializeField] private List<InteractiveObject> _buttonsMap;
    [Space]
    [SerializeField] private List<Button> _allButtons;

    private void Awake()
    {
        foreach (var buttonInfo in _buttonsMap)
        {
            buttonInfo.Setup();
        }
    }
}
