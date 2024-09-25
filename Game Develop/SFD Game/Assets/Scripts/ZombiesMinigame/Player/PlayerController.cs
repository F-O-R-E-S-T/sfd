using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZombiesMinigame
{
    public class PlayerController : MonoBehaviour
    {
        public float speed = 6.0f;        // Velocidad de movimiento del personaje
        public float gravity = -9.8f;     // Gravedad aplicada al personaje

        private Rigidbody _rb;

        private PlayerStats _playerStats;

        public enum FloorType
        {
            Dirt,
            Concrete
        }

        public FloorType floorType = FloorType.Concrete;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _playerStats = GetComponent<PlayerStats>();
        }


        void Update()
        {
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveZ = Input.GetAxisRaw("Vertical");

            Vector3 direction = new Vector3(moveX, 0, moveZ);

            _rb.velocity = direction.normalized * _playerStats.MoveSpeed;

            if(direction.magnitude > 0)
            {
                if(floorType == FloorType.Dirt)
                {
                    if(!AudioManager.Instance.PlayerFootstepsDirtAudioSource.isPlaying)
                        AudioManager.Instance.PlayerFootstepsDirtAudioSource.Play();
                }
                else
                {
                    if (!AudioManager.Instance.PlayerFootstepsConcreteAudioSource.isPlaying)
                        AudioManager.Instance.PlayerFootstepsConcreteAudioSource.Play();
                }
            }
        }
    }
}

