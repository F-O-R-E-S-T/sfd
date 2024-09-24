using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZombiesMinigame
{
    public class Bullet : MonoBehaviour
    {
        public float forceAmount = 10f;
        public float damage = 10f; // Daño que hace la bala

        private Rigidbody rb;
        private Transform player;
        private PlayerStats _playerStats;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            player = FindObjectOfType<PlayerController>().transform;
            _playerStats = player.GetComponent<PlayerStats>();
        }

        private void OnEnable()
        {
            
            if (rb != null)
            {
                rb.velocity = Vector3.zero; // Reset velocity
                rb.AddForce(-player.right * forceAmount, ForceMode.Impulse);
            }

            // Desactiva la bala después de un tiempo para reutilizarla
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
                gameObject.SetActive(false); // Desactiva la bala
            }
        }
    }
}