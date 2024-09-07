using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _cameraZOffset = -15;
    

    void Update()
    {
        transform.position = new Vector3(_player.transform.position.x, transform.position.y, _player.transform.position.z + _cameraZOffset);
    }
}
