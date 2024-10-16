using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;

    [SerializeField] private float _damage = 10;
    [SerializeField] private float _moveSpeed = 6;
    [SerializeField] private float _attackSpeed = 1;

    public float Damage { get => _damage; set => _damage = value; }
    public float MoveSpeed { get => _moveSpeed; set => _moveSpeed = value; }
    public float AttackSpeed { get => _attackSpeed; set => _attackSpeed = value; }


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

}
