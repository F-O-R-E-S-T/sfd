using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZombiesMinigame
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _forceAmount = 10f;
        [SerializeField] private float _damage = 10f;

        private Rigidbody _rb;
        private Transform _player;
        private PlayerStats _playerStats;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _player = FindObjectOfType<PlayerController>().transform;
            _playerStats = _player.GetComponent<PlayerStats>();
        }

        private void OnEnable()
        {
            
            if (_rb != null)
            {
                _rb.velocity = Vector3.zero;
                _rb.AddForce(-_player.right * _forceAmount, ForceMode.Impulse);
                AudioManager.Instance.PlayerShootAudioSource.Play();
            }

            StartCoroutine(DeactivateAfterTime(2f));
        }

        private IEnumerator DeactivateAfterTime(float time)
        {
            yield return new WaitForSeconds(time);
            gameObject.SetActive(false);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(_playerStats.Damage);
                }
                gameObject.SetActive(false);
            }
        }
    }
}