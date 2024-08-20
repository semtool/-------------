using UnityEngine;

[RequireComponent(typeof(Robber))]

public class Spawner : MonoBehaviour
{
    [SerializeField] private Robber _robber;
    [SerializeField] private float _startPositionX;
    [SerializeField] private float _startPositionZ;

    private float _startPositionY = 0f;

    private void Start()
    {
        Instantiate(_robber, _robber.SetSelfStartPosition(_startPositionX,_startPositionY,_startPositionZ), Quaternion.identity);
    }
}