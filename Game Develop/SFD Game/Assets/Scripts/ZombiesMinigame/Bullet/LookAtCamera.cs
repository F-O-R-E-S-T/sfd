using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZombiesMinigame
{
    public class LookAtCamera : MonoBehaviour
    {
        private Camera _mainCamera;

        void Start()
        {
            _mainCamera = Camera.main;
        }

        void Update()
        {
            if (_mainCamera != null)
            {
                transform.LookAt(_mainCamera.transform);
            }
        }
    }
}


