using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZombiesMinigame
{
    public class EnemyHealth : MonoBehaviour
    {
        public float maxHealth = 100f; // Vida máxima del enemigo
        private float currentHealth;

        void Start()
        {
            currentHealth = maxHealth; // Iniciar con vida máxima
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
            // Aquí puedes agregar efectos de muerte, animaciones, etc.
            gameObject.SetActive(false); // Desactiva el enemigo
        }
    }
}