using UnityEngine;

public class ScreenVibration : MonoBehaviour
{
    [SerializeField] private Transform player; // Asigna el jugador en el inspector
    [SerializeField] private Vector3 offset; // Desplazamiento entre el jugador y la c�mara

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
        // Actualizar la posici�n de la c�mara para seguir al jugador
        Camera.main.transform.position = player.position + offset;

        if (_isVibrating)
        {
            if (_elapsedTime < _vibrationDuration)
            {
                _elapsedTime += Time.deltaTime;

                // Agregar el efecto de vibraci�n a la posici�n actual
                Camera.main.transform.position += Random.insideUnitSphere * _vibrationIntensity;
            }
            else
            {
                _isVibrating = false;
            }
        }
    }
}