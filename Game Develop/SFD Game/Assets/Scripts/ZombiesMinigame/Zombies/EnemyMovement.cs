using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace ZombiesMinigame
{
    public class EnemyMovement : MonoBehaviour
    {
        private NavMeshAgent _agent;
        private Transform _player;

        // Start is called before the first frame update
        void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
            _player = FindObjectOfType<PlayerController>().transform;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (_agent.enabled)
                _agent.SetDestination(_player.position);
        }
    }
}


