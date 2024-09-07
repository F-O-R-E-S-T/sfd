using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;  // Prefab del enemigo
    public float spawnInterval = 3f;  // Intervalo de tiempo inicial entre spawns
    public float minSpawnInterval = 0.5f;  // Intervalo de tiempo mínimo entre spawns
    public float decreaseRate = 0.01f;  // Tasa de disminución del intervalo de tiempo por segundo
    public Transform[] spawnPoints;  // Puntos de generación de enemigos

    private float timer;

    void Start()
    {
        timer = spawnInterval;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            SpawnEnemy();
            timer = spawnInterval;
        }

        // Reducir el intervalo de spawn progresivamente
        if (spawnInterval > minSpawnInterval)
        {
            spawnInterval -= decreaseRate * Time.deltaTime;
            if (spawnInterval < minSpawnInterval)
            {
                spawnInterval = minSpawnInterval;
            }
        }
    }

    void SpawnEnemy()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[spawnIndex];

        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}