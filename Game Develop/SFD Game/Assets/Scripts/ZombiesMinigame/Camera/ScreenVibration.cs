using UnityEngine;

public class ScreenVibration : MonoBehaviour
{
    [SerializeField] private float _vibrationDuration = 1f;
    [SerializeField] private float _vibrationIntensity = 0.1f;
    [SerializeField] private Vector3 _originalPosition;
    [SerializeField] private bool _isVibrating = false;
    [SerializeField] private float _elapsedTime = 0f;

    public void VibrateScreen()
    {
        if (!_isVibrating)
        {
            _originalPosition = Camera.main.transform.position;
            _isVibrating = true;
            _elapsedTime = 0f;
        }
    }

    void Update()
    {
        if (_isVibrating)
        {
            if (_elapsedTime < _vibrationDuration)
            {
                _elapsedTime += Time.deltaTime;
                Camera.main.transform.position = _originalPosition + (Random.insideUnitSphere * _vibrationIntensity);
            }
            else
            {
                _isVibrating = false;
                Camera.main.transform.position = _originalPosition;
            }
        }
    }
}