using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace ZombiesMinigame
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private float _currentLife;
        [SerializeField] private float _maxLife;
        [SerializeField] private ParticleSystem _shockwaveParticle;
        [SerializeField] private ParticleSystem _hurtParticle;
        [SerializeField] private ScreenVibration _screenVibration;


        public float CurrentLife { get => _currentLife; }

        [SerializeField] private float _pushForce = 10f;
        [SerializeField] private float _pushRadius = 10f;
        [SerializeField] private float _deathRadius = 3f;
        [SerializeField] private float _disableTime = 0.5f;

        [SerializeField] private float _damageReceived = 20f;

        [SerializeField] private PlayerHealthUI _playerHealthUI;
        [SerializeField] private GameObject _gameOverPanel;

        [SerializeField] private PlayerController _playerController;
        [SerializeField] private SpawnOnHold _spawnOnHold;
        [SerializeField] private CreateOrbs _createOrbs;
        [SerializeField] private LookAtMouse _lookAtMouse;

        private void Awake()
        {
            _currentLife = _maxLife;
        }

        private void Update()
        {
            if(_currentLife <= 0 && !_gameOverPanel.activeInHierarchy)
            {
                _gameOverPanel.SetActive(true);
                _playerController.enabled = false;
                _spawnOnHold.enabled = false;
                _lookAtMouse.enabled = false;
                AudioManager.Instance.PlayerDieAudioSource.Play();
                Time.timeScale = 0;
                this.enabled = false;

            }
        }

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                KillEnemies();
                _shockwaveParticle.Play();
                _hurtParticle.Play();
                PushEnemiesBack();
                AudioManager.Instance.PlayerHurtAudioSource.Play();

                _currentLife -= _damageReceived;
                _currentLife = Mathf.Clamp(_currentLife, 0, _maxLife);
                _playerHealthUI.UpdateHealthUI(_currentLife);

                _screenVibration.VibrateScreen();
            }
        }

        void KillEnemies()
        {
            Collider[] enemies = Physics.OverlapSphere(transform.position, _deathRadius);

            foreach (Collider enemy in enemies)
            {
                if (enemy.CompareTag("Enemy"))
                {
                    enemy.GetComponent<EnemyHealth>().Die();
                }
            }
        }

        void PushEnemiesBack()
        {
            Collider[] enemies = Physics.OverlapSphere(transform.position, _pushRadius);

            foreach (Collider enemy in enemies)
            {
                if (enemy.CompareTag("Enemy"))
                {
                    NavMeshAgent agent = enemy.GetComponent<NavMeshAgent>();
                    Rigidbody rb = enemy.GetComponent<Rigidbody>();

                    if (agent != null && rb != null)
                    {
                        agent.enabled = false;
                        Vector3 direction = (enemy.transform.position - transform.position).normalized;
                        rb.AddForce(direction * _pushForce, ForceMode.Impulse);
                        StartCoroutine(EnableNavMeshAgent(agent, _disableTime));

                    }
                }
            }

        }

        IEnumerator EnableNavMeshAgent(NavMeshAgent agent, float delay)
        {
            yield return new WaitForSeconds(delay);
            agent.enabled = true;
        }
    }

}

