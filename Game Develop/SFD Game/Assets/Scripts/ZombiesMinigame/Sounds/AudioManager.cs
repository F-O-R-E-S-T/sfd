using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Sources")]
    [Space(20)]
    [SerializeField] public AudioSource PlayerFootstepsConcreteAudioSource;
    [SerializeField] public AudioSource PlayerFootstepsDirtAudioSource;
    [SerializeField] public AudioSource PlayerHurtAudioSource;
    [SerializeField] public AudioSource EnemyHurtAudioSource;
    [SerializeField] public AudioSource PlayerDieAudioSource;
    [SerializeField] public AudioSource PlayerShootAudioSource;

    public static AudioManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }
}
