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

        public float pushForce = 10f;
        public float pushRadius = 10f;
        public float deathRadius = 3f;
        public float disableTime = 0.5f;  // Tiempo que se desactiva el NavMeshAgent

        public float damageReceived = 20f;

        public PlayerHealthUI playerHealthUI;
        public GameObject GameOverPanel;

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
            if(_currentLife <= 0 && !GameOverPanel.activeInHierarchy)
            {
                GameOverPanel.SetActive(true);
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

                _currentLife -= damageReceived;
                _currentLife = Mathf.Clamp(_currentLife, 0, _maxLife);
                playerHealthUI.UpdateHealthUI(_currentLife);

                _screenVibration.VibrateScreen();
            }
        }

        void KillEnemies()
        {
            Collider[] enemies = Physics.OverlapSphere(transform.position, deathRadius);

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
            Collider[] enemies = Physics.OverlapSphere(transform.position, pushRadius);

            foreach (Collider enemy in enemies)
            {
                if (enemy.CompareTag("Enemy"))
                {
                    NavMeshAgent agent = enemy.GetComponent<NavMeshAgent>();
                    Rigidbody rb = enemy.GetComponent<Rigidbody>();

                    if (agent != null && rb != null)
                    {
                        // Desactiva el NavMeshAgent
                        agent.enabled = false;
                        // Aplica la fuerza
                        Vector3 direction = (enemy.transform.position - transform.position).normalized;
                        rb.AddForce(direction * pushForce, ForceMode.Impulse);
                        // Reactiva el NavMeshAgent después de un tiempo
                        StartCoroutine(EnableNavMeshAgent(agent, disableTime));

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

