using UnityEngine;

public class Robber : MonoBehaviour
{
    [SerializeField] private float _speed;

    public Vector3 SetSelfStartPosition(float xCoordinate, float yCoordinate, float zCoordinate)
    {
        return new Vector3(xCoordinate, yCoordinate, zCoordinate);
    }
}