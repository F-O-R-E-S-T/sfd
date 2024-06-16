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
            // Obtener la cámara principal
            mainCamera = Camera.main;
        }

        void Update()
        {
            // Asegurarse de que la cámara principal no sea nula
            if (mainCamera != null)
            {
                // Hacer que el objeto mire a la cámara
                transform.LookAt(mainCamera.transform);
            }
        }
    }
}


