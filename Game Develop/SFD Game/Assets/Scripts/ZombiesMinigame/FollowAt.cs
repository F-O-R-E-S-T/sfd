using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAt : MonoBehaviour
{
    [SerializeField] private GameObject _objectToFollow;

    
    void Update()
    {
        transform.position = _objectToFollow.transform.position;
    }
}
