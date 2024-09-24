using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZombiesMinigame
{
    public class SpawnOnHold : MonoBehaviour
    {
        public string bulletTag; // El tag del objeto a instanciar
        public GameObject objectToSpawn; // El objeto a instanciar
        public Transform spawnPoint; // El punto de spawn
        public float spawnDelay = 1f; // Retardo en segundos entre instanciaciones
        public float forceAmount = 10f; // Fuerza a aplicar
        public float MaximumAttackSpeed = 2;

        private bool isSpawning = false; // Para controlar si se está instanciando
        private float nextSpawnTime; // Para controlar el tiempo de la próxima instanciación
        private Coroutine spawnCoroutine; // Para controlar la corrutina de spawn

        private PlayerStats _playerStats;

        private void Awake()
        {
            _playerStats = GetComponent<PlayerStats>();
        }

        void Update()
        {
            if (Input.GetMouseButton(0))
            {
                // Comienza a instanciar cuando se mantiene presionado el botón izquierdo del mouse
                if (!isSpawning)
                {
                    isSpawning = true;
                    spawnCoroutine = StartCoroutine(SpawnRoutine());
                }
            }
            else
            {
                // Deja de instanciar cuando se suelta el botón izquierdo del mouse
                if (isSpawning)
                {
                    isSpawning = false;
                    StopCoroutine(spawnCoroutine);
                }
            }
        }

        private IEnumerator SpawnRoutine()
        {
            // Instanciar el objeto en el punto de spawn
            //GameObject spawnedObject = Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);

            // Aplicar una fuerza al objeto instanciado
            //Rigidbody rb = spawnedObject.GetComponent<Rigidbody>();
            //if (rb != null)
            //{
                //rb.AddForce(-spawnedObject.transform.up * forceAmount, ForceMode.Impulse);
            //}

            ObjectPoolManager.Instance.SpawnFromPool(bulletTag, spawnPoint.position, spawnPoint.rotation);
            // Esperar el tiempo de retardo antes de la próxima instanciación
            float timeToWait = Mathf.Clamp(MaximumAttackSpeed - _playerStats.AttackSpeed, 1, MaximumAttackSpeed);
            yield return new WaitForSeconds(timeToWait);
            isSpawning = false;
        }
    }
}


