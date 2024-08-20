using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speedOfMoving;
    [SerializeField] private float _speedOfRotation;

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * _speedOfMoving * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-Vector3.forward * _speedOfMoving * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * _speedOfRotation * Time.deltaTime, Space.Self);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate( - Vector3.up * _speedOfRotation * Time.deltaTime, Space.Self);
        }
    }
}