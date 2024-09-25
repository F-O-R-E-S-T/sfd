using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace ZombiesMinigame
{
    public class EnemyHealth : MonoBehaviour
    {
        public float maxHealth = 100f; // Vida m�xima del enemigo
        private float currentHealth;

        [SerializeField] private ParticleSystem _hurtParticle;
        [SerializeField] private GameObject _floatingTextPrefab;

        void Start()
        {
            currentHealth = maxHealth; // Iniciar con vida m�xima
        }

        public void TakeDamage(float amount)
        {
            currentHealth -= amount;
            _hurtParticle.Play();
            AudioManager.Instance.EnemyHurtAudioSource.Play();
            ShowFloatingText(amount);

            if (currentHealth <= 0)
            {
                Die();
            }
        }

        public void Die()
        {
            // Aqu� puedes agregar efectos de muerte, animaciones, etc.
            gameObject.SetActive(false); // Desactiva el enemigo
        }

        private void ShowFloatingText(float damage)
        {
            Vector3 spawnPoint = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z);
            var go = Instantiate(_floatingTextPrefab, spawnPoint, Quaternion.identity, transform);
            go.GetComponent<TextMeshPro>().text = Mathf.Ceil(damage).ToString();
        }
    }
}