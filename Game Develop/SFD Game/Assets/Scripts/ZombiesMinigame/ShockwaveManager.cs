using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockwaveManager : MonoBehaviour
{
    [SerializeField] private float _shockWaveTime = 0.75f;
    private Coroutine _shockWaveCoroutine;

    private Material _shockwaveMaterial;

    private static int _waveDistanceFromCenter = Shader.PropertyToID("_WaveDistanceFromCenter");

    private void Awake()
    {
        _shockwaveMaterial = GetComponent<SpriteRenderer>().material;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CallShockWave();
        }
    }

    public void CallShockWave()
    {
        _shockWaveCoroutine = StartCoroutine(ShockWaveAction(-0.1f, 1f));
    }

    private IEnumerator ShockWaveAction(float startPosition, float endPosition)
    {
        _shockwaveMaterial.SetFloat(_waveDistanceFromCenter, startPosition);

        float lerpedAmount = 0f;

        float elapsedTime = 0f;
        while(elapsedTime < _shockWaveTime)
        {
            elapsedTime += Time.deltaTime;
            lerpedAmount = Mathf.Lerp(startPosition, endPosition, (elapsedTime / _shockWaveTime));
            _shockwaveMaterial.SetFloat(_waveDistanceFromCenter, lerpedAmount);

            yield return null;
        }
    }
}
