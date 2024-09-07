using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public float detectionRadius = 5f; // El radio de detecci�n
    public float pushForce = 10f; // La fuerza con la que se empujar�n los enemigos

    void OnCollisionEnter(Collision collision)
    {
        // Verificar si el objeto colisionado tiene el tag "Enemy"
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Obtener todos los objetos con el tag "Enemy" en un radio de detecci�n
            Collider[] enemies = Physics.OverlapSphere(transform.position, detectionRadius);

            foreach (Collider enemy in enemies)
            {
                if (enemy.CompareTag("Enemy"))
                {
                    // Calcular la direcci�n para empujar hacia atr�s
                    Vector3 pushDirection = enemy.transform.position - transform.position;
                    pushDirection.y = 0; // Asegurarse de que la fuerza solo se aplique en el plano XZ
                    pushDirection.Normalize();

                    // Aplicar la fuerza para empujar hacia atr�s
                    Rigidbody enemyRigidbody = enemy.GetComponent<Rigidbody>();
                    if (enemyRigidbody != null)
                    {
                        enemyRigidbody.AddForce(pushDirection * pushForce, ForceMode.Impulse);
                    }
                }
            }
        }
    }

    // Visualizaci�n del radio de detecci�n en la vista de escena para facilitar el ajuste
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}