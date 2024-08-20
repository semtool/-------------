using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class ProtectedSpace : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private Coroutine _coroutineForIncreasing;
    private Coroutine _coroutineForDecreasing;
    private float _minVolue = 0f;
    private float _currentVolue = 0f;
    private float _maxVolue = 1f;
    private float _spetOfIcrease = 0.3f;
    private float _minPitch = 1f;
    private float _currentPitch = 1f;
    private float _maxPitch = 2f;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Robber robber))
        {
            if (_coroutineForDecreasing != null)
            {
                StopCoroutine(_coroutineForDecreasing);
            }

            _coroutineForIncreasing = StartCoroutine(ChangeSoundUp());

            _audioSource.loop = true;

            if (_currentVolue == 0)
            {
                _audioSource.Play(0);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Robber robber))
        {
            if (_coroutineForIncreasing != null)
            {
                StopCoroutine(_coroutineForIncreasing);
            }

            _coroutineForDecreasing = StartCoroutine(ChangeSoundDown());
        }
    }

    IEnumerator ChangeSoundUp()
    {
        while (true)
        {
            var wait = new WaitForSeconds(0);

            yield return wait;

            ChangeSound(_maxVolue, _maxPitch);
        }
    }

    IEnumerator ChangeSoundDown()
    {
        while (true)
        {
            var wait = new WaitForSeconds(0);

            yield return wait;

            ChangeSound(_minVolue, _minPitch);
        }
    }

    private void ChangeSound(float volueLimit, float pitchLimit)
    {
        _currentVolue = Mathf.MoveTowards(_currentVolue, volueLimit, _spetOfIcrease * Time.deltaTime);
        _currentPitch = Mathf.MoveTowards(_currentPitch, pitchLimit, _spetOfIcrease * Time.deltaTime);

        _audioSource.volume = _currentVolue;
        _audioSource.pitch = _currentPitch;
    }
}