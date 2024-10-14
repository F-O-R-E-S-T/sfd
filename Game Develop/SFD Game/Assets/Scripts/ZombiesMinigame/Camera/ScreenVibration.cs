using UnityEngine;

public class ScreenVibration : MonoBehaviour
{
    [SerializeField] private Transform player; // Asigna el jugador en el inspector
    [SerializeField] private Vector3 offset; // Desplazamiento entre el jugador y la cámara

    [SerializeField] private float _vibrationDuration = 1f;
    [SerializeField] private float _vibrationIntensity = 0.1f;
    [SerializeField] private Vector3 _originalPosition;
    [SerializeField] private bool _isVibrating = false;
    [SerializeField] private float _elapsedTime = 0f;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

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
        // Actualizar la posición de la cámara para seguir al jugador
        Camera.main.transform.position = player.position + offset;

        if (_isVibrating)
        {
            if (_elapsedTime < _vibrationDuration)
            {
                _elapsedTime += Time.deltaTime;

                // Agregar el efecto de vibración a la posición actual
                Camera.main.transform.position += Random.insideUnitSphere * _vibrationIntensity;
            }
            else
            {
                _isVibrating = false;
            }
        }
    }
}