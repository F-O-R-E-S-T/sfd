using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZombiesMinigame
{
    public class EnemyHealth : MonoBehaviour
    {
        public float maxHealth = 100f; // Vida m�xima del enemigo
        private float currentHealth;

        void Start()
        {
            currentHealth = maxHealth; // Iniciar con vida m�xima
        }

        public void TakeDamage(float amount)
        {
            currentHealth -= amount;

            if (currentHealth <= 0)
            {
                Die();
            }
        }

        void Die()
        {
            // Aqu� puedes agregar efectos de muerte, animaciones, etc.
            gameObject.SetActive(false); // Desactiva el enemigo
        }
    }
}