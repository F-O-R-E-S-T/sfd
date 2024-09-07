using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public float detectionRadius = 5f; // El radio de detección
    public float pushForce = 10f; // La fuerza con la que se empujarán los enemigos

    void OnCollisionEnter(Collision collision)
    {
        // Verificar si el objeto colisionado tiene el tag "Enemy"
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Obtener todos los objetos con el tag "Enemy" en un radio de detección
            Collider[] enemies = Physics.OverlapSphere(transform.position, detectionRadius);

            foreach (Collider enemy in enemies)
            {
                if (enemy.CompareTag("Enemy"))
                {
                    // Calcular la dirección para empujar hacia atrás
                    Vector3 pushDirection = enemy.transform.position - transform.position;
                    pushDirection.y = 0; // Asegurarse de que la fuerza solo se aplique en el plano XZ
                    pushDirection.Normalize();

                    // Aplicar la fuerza para empujar hacia atrás
                    Rigidbody enemyRigidbody = enemy.GetComponent<Rigidbody>();
                    if (enemyRigidbody != null)
                    {
                        enemyRigidbody.AddForce(pushDirection * pushForce, ForceMode.Impulse);
                    }
                }
            }
        }
    }

    // Visualización del radio de detección en la vista de escena para facilitar el ajuste
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}