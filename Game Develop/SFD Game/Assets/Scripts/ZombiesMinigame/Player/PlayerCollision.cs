using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private float _detectionRadius = 5f;
    [SerializeField] private float _pushForce = 10f;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Collider[] enemies = Physics.OverlapSphere(transform.position, _detectionRadius);

            foreach (Collider enemy in enemies)
            {
                if (enemy.CompareTag("Enemy"))
                {
                    
                    Vector3 pushDirection = enemy.transform.position - transform.position;
                    pushDirection.y = 0;
                    pushDirection.Normalize();

                    Rigidbody enemyRigidbody = enemy.GetComponent<Rigidbody>();
                    if (enemyRigidbody != null)
                    {
                        enemyRigidbody.AddForce(pushDirection * _pushForce, ForceMode.Impulse);
                    }
                }
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _detectionRadius);
    }
}