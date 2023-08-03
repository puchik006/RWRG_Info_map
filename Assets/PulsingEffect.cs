using UnityEngine;


public class PulsingEffect : MonoBehaviour
{
    [SerializeField] private float _pulseSpeed = 2f;
    [SerializeField] private float _pulseAmplitude = 0.01f;
    private float _sinTime = 0f;
    private Vector3 _originalScale;

    private void Start()
    {
        _originalScale = transform.localScale;
    }

    private void Update()
    {
        _sinTime += Time.deltaTime;
        float newScale = _originalScale.x + Mathf.Sin(_sinTime * _pulseSpeed) * _pulseAmplitude;
        transform.localScale = new Vector3(newScale, newScale, 1f);
    }
}

