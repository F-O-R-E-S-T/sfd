using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace ZombiesMinigame
{
    public class EnemyMovement : MonoBehaviour
    {
        private NavMeshAgent agent;
        private Transform player;

        // Start is called before the first frame update
        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            player = FindObjectOfType<PlayerController>().transform;
        }

        // Update is called once per frame
        void Update()
        {
            if(agent.enabled)
                agent.SetDestination(player.position);
        }
    }
}


