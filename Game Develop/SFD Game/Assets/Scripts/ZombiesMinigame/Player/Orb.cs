using UnityEngine;

namespace ZombiesMinigame
{
    public class Orb : MonoBehaviour
    {
        private GameObject _player;
        [SerializeField] private float _radius;
        [SerializeField] private float _angle;

        [SerializeField] private float _rotationVelocity;

        private PlayerStats _playerStats;

        private float _yRotation;

        private void Start()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
            _playerStats = _player.GetComponent<PlayerStats>();

            _yRotation = transform.position.y - 3f;
        }

        private void Update()
        {
            OrbRotation();
        }

        private void OrbRotation()
        {
            float posX = _player.transform.position.x + Mathf.Cos(_angle * Mathf.Deg2Rad) * _radius;
            float posZ = _player.transform.position.z + Mathf.Sin(_angle * Mathf.Deg2Rad) * _radius;

            transform.position = new Vector3(posX, _yRotation, posZ);
            _angle += _rotationVelocity * _playerStats.AttackSpeed * Time.deltaTime;
        }

        public void SetAngle(float angle)
        {
            _angle = angle;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(_playerStats.Damage);
                }
            }
        }
    }

}
