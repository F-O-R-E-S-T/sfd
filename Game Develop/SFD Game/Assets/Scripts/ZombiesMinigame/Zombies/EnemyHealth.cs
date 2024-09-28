using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace ZombiesMinigame
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] private float _maxHealth = 100f;
        private float _currentHealth;

        [SerializeField] private ParticleSystem _hurtParticle;
        [SerializeField] private GameObject _floatingTextPrefab;

        void Start()
        {
            _currentHealth = _maxHealth;
        }

        public void TakeDamage(float amount)
        {
            _currentHealth -= amount;
            _hurtParticle.Play();
            AudioManager.Instance.EnemyHurtAudioSource.Play();
            ShowFloatingText(amount);

            if (_currentHealth <= 0)
            {
                Die();
            }
        }

        public void Die()
        {
            gameObject.SetActive(false);
        }

        private void ShowFloatingText(float damage)
        {
            Vector3 spawnPoint = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z);
            var go = Instantiate(_floatingTextPrefab, spawnPoint, Quaternion.identity, transform);
            go.GetComponent<TextMeshPro>().text = Mathf.Ceil(damage).ToString();
        }
    }
}