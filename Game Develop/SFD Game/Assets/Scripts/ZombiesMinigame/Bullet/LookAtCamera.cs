using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZombiesMinigame
{
    public class LookAtCamera : MonoBehaviour
    {
        private Camera mainCamera;

        void Start()
        {
            // Obtener la c�mara principal
            mainCamera = Camera.main;
        }

        void Update()
        {
            // Asegurarse de que la c�mara principal no sea nula
            if (mainCamera != null)
            {
                // Hacer que el objeto mire a la c�mara
                transform.LookAt(mainCamera.transform);
            }
        }
    }
}


