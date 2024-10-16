using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZombiesMinigame
{
    public class SpawnOnHold : MonoBehaviour
    {
        [SerializeField] private string _bulletTag;
        [SerializeField] private GameObject _objectToSpawn;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private float _spawnDelay = 1f;
        [SerializeField] private float _forceAmount = 10f;
        [SerializeField] private float _maximumAttackSpeed = 2;

        [SerializeField] private bool _isSpawning = false;
        [SerializeField] private float _nextSpawnTime;
        [SerializeField] private Coroutine _spawnCoroutine;

        private PlayerStats _playerStats;

        private void Awake()
        {
            _playerStats = GetComponent<PlayerStats>();
        }

        void Update()
        {
            if (Input.GetMouseButton(0))
            {
                if (!_isSpawning)
                {
                    _isSpawning = true;
                    _spawnCoroutine = StartCoroutine(SpawnRoutine());
                }
            }
            else
            {
                if (_isSpawning)
                {
                    _isSpawning = false;
                    StopCoroutine(_spawnCoroutine);
                }
            }
        }

        private IEnumerator SpawnRoutine()
        {
            ObjectPoolManager.Instance.SpawnFromPool(_bulletTag, _spawnPoint.position, _spawnPoint.rotation);
            float timeToWait = Mathf.Clamp(_maximumAttackSpeed - _playerStats.AttackSpeed, 1, _maximumAttackSpeed);
            yield return new WaitForSeconds(timeToWait);
            _isSpawning = false;
        }
    }
}


