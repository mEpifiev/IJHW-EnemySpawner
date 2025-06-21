using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 3f;

    private EnemyTarget _target;

    private void Update()
    {
        MoveToTarget();
    }

    public void SetTarget(EnemyTarget target)
    {
        _target = target;
    }

    private void MoveToTarget()
    {
        if (_target == null)
            return;

        transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, _moveSpeed * Time.deltaTime);

        transform.rotation = Quaternion.LookRotation(_target.transform.position);
    }
}
