using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private Vector3 _direction;

    public void Initialize(Vector3 direction)
    {
        _direction = direction;
    }

    private void Update()
    {
        transform.Translate(_direction * _moveSpeed * Time.deltaTime);
    }
}
