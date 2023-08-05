using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Graphic))]
public class PulsingImage : MonoBehaviour
{
    private Graphic _imageToPulse;
    [SerializeField] private float _pulseSpeed = 6f;
    [SerializeField] private float _pulseAmplitude = 0.01f;

    private void Awake()
    {
        _imageToPulse = GetComponent<Graphic>();
    }

    private void OnEnable()
    {
        StartCoroutine(_imageToPulse.Pulse(_pulseSpeed, _pulseAmplitude));
    }
}

