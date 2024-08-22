using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class ProtectedSpace : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private Coroutine _coroutineForChanging;
    private float _minVolue = 0f;
    private float _currentVolue = 0f;
    private float _maxVolue = 1f;
    private float _spetOfIcrease = 0.3f;
    private float _minPitch = 1f;
    private float _currentPitch = 1f;
    private float _maxPitch = 2f;

    private void OnTriggerEnter(Collider other)
    {
        if (HasDetectedRobber(other))
        {
            DeactivateCoroutine();

            ActivateCoroutine(_maxVolue, _maxPitch);

            _audioSource.loop = true;

            if (_currentVolue == 0)
            {
                _audioSource.Play(0);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (HasDetectedRobber(other))
        {
            DeactivateCoroutine();

            ActivateCoroutine(_minVolue, _minPitch);
        }
    }

    IEnumerator ChangeSound(float volueLimit, float pitchLimit)
    {
        while (true)
        {
            yield return null;

            ChangeVolue(volueLimit);
            ChangePitch(pitchLimit);
        }
    }

    private bool HasDetectedRobber(Collider other)
    {
        return other.gameObject.TryGetComponent(out Robber robber);
    }

    private void ActivateCoroutine(float volueLimit, float pitchLimit)
    {
        _coroutineForChanging = StartCoroutine(ChangeSound(volueLimit, pitchLimit));
    }

    private void DeactivateCoroutine()
    {
        if (_coroutineForChanging != null)
        {
            StopCoroutine(_coroutineForChanging);
        }
    }

    private void ChangeVolue(float volueLimit)
    {
        _currentVolue = Mathf.MoveTowards(_currentVolue, volueLimit, _spetOfIcrease * Time.deltaTime);
        _audioSource.volume = _currentVolue;
    }

    private void ChangePitch(float pitchLimit)
    {
        _currentPitch = Mathf.MoveTowards(_currentPitch, pitchLimit, _spetOfIcrease * Time.deltaTime);
        _audioSource.pitch = _currentPitch;
    }
}