using UnityEngine;

public class ScreenVibration : MonoBehaviour
{
    public float vibrationDuration = 1f; // Duraci�n de la vibraci�n en segundos
    public float vibrationIntensity = 0.1f; // Intensidad de la vibraci�n
    private Vector3 originalPosition;
    private bool isVibrating = false;
    private float elapsedTime = 0f;

    // M�todo p�blico para activar la vibraci�n
    public void VibrateScreen()
    {
        if (!isVibrating)
        {
            originalPosition = Camera.main.transform.position;
            isVibrating = true;
            elapsedTime = 0f;
        }
    }

    void Update()
    {
        if (isVibrating)
        {
            if (elapsedTime < vibrationDuration)
            {
                elapsedTime += Time.deltaTime;
                Camera.main.transform.position = originalPosition + (Random.insideUnitSphere * vibrationIntensity);
            }
            else
            {
                isVibrating = false;
                Camera.main.transform.position = originalPosition; // Restaurar la posici�n original
            }
        }
    }
}