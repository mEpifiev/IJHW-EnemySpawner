using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyTarget : MonoBehaviour
{
    [SerializeField] private List<WayPoints> _wayPoints;

    [SerializeField] private float _moveSpeed = 5f;

    private int _currentWayPoint;

    private void Awake()
    {
        if(_wayPoints != null)
            transform.position = _wayPoints[_currentWayPoint].transform.position;
    }

    private void Update()
    {
        MoveByWayPoints();
    }

    private void MoveByWayPoints()
    {
        if (_wayPoints == null || _wayPoints.Count == 0)
            return;

        if(transform.position == _wayPoints[_currentWayPoint].transform.position)
            _currentWayPoint = (_currentWayPoint + 1) % _wayPoints.Count;

        transform.position = Vector3.MoveTowards(transform.position, _wayPoints[_currentWayPoint].transform.position, _moveSpeed * Time.deltaTime);

        Vector3 direction = _wayPoints[_currentWayPoint].transform.position - transform.position;
        direction.y = 0; 

        transform.rotation = Quaternion.LookRotation(direction);
    }
}