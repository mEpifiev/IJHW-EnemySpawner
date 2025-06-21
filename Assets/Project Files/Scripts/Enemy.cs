using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private Vector3 _direction;

    public void Initialize(Vector3 direction)
    {
        _direction = direction;

        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;
    }

    private void Update()
    {
        transform.Translate(_direction * _moveSpeed * Time.deltaTime, Space.World);
    }
}
