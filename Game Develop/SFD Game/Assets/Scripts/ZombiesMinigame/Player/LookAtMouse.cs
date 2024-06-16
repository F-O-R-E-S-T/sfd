using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZombiesMinigame
{
    public class LookAtMouse : MonoBehaviour
    {
        void Update()
        {
            // Obtener la posici�n del mouse en la pantalla
            Vector3 mousePosition = Input.mousePosition;

            // Convertir la posici�n del mouse a una posici�n en el mundo
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                // Obtener la posici�n del punto donde el raycast impacta
                Vector3 targetPosition = hit.point;

                // Calcular la direcci�n hacia el objetivo
                Vector3 direction = targetPosition - transform.position;
                direction.y = 0; // Mantener la direcci�n en el plano XZ

                // Rotar el objeto para que mire hacia la direcci�n del objetivo
                if (direction != Vector3.zero)
                {
                    Quaternion targetRotation = Quaternion.LookRotation(direction);

                    // Sumar 90 grados en el eje Y
                    Quaternion additionalRotation = Quaternion.Euler(0, 90, 0);
                    targetRotation *= additionalRotation;

                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
                }
            }
        }
    }

}

