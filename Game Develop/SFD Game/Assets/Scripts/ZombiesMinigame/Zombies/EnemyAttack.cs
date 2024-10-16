using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{

    private NavMeshAgent _agent;
    [SerializeField] private float _radiusDetection = 5f;
    private GameObject _player;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, _player.transform.position) <= _radiusDetection)
        {
            _agent.enabled = false;
        }
        else
        {
            _agent.enabled = true;
        }
    }
}
