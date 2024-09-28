using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _spawnInterval = 3f;
    [SerializeField] private float _minSpawnInterval = 0.5f;
    [SerializeField] private float _decreaseRate = 0.01f;
    [SerializeField] private Transform[] _spawnPoints;

    private float _timer;

    void Start()
    {
        _timer = _spawnInterval;
    }

    void Update()
    {
        _timer -= Time.deltaTime;

        if (_timer <= 0)
        {
            SpawnEnemy();
            _timer = _spawnInterval;
        }

        if (_spawnInterval > _minSpawnInterval)
        {
            _spawnInterval -= _decreaseRate * Time.deltaTime;
            if (_spawnInterval < _minSpawnInterval)
            {
                _spawnInterval = _minSpawnInterval;
            }
        }
    }

    void SpawnEnemy()
    {
        int spawnIndex = Random.Range(0, _spawnPoints.Length);
        Transform spawnPoint = _spawnPoints[spawnIndex];

        Instantiate(_enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}