using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Mover : MonoBehaviour
{
    private const string HorizontalAxis = "Horizontal";
    private const string VerticalAxis = "Vertical";

    private Rigidbody _rigidbody;
    private float _horizontal;
    private float _vertical;
    private int _multiplicatorOfForce = 5;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _horizontal = Input.GetAxis(HorizontalAxis);
        _vertical = Input.GetAxis(VerticalAxis);

        Vector3 directionOfMove = new Vector3(_horizontal, 0f, _vertical);

        _rigidbody.AddForce(directionOfMove * _multiplicatorOfForce, ForceMode.Force);
    }
}