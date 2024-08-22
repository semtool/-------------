using UnityEngine;

public class MoverTwo : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Vector3 _directionOfMove;

    private float _horizontal;
    private float _vertical;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
        _directionOfMove = new Vector3(_horizontal, 0f, _vertical);

        _rigidbody.AddForce(_directionOfMove * 5, ForceMode.Force);
    }
}