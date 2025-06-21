using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private readonly Vector3[] Directions = new Vector3[] {
        Vector3.right,
        Vector3.left,
        Vector3.forward
    };

    [SerializeField] private SpawnPoint[] _points;
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private float _delay;
    [SerializeField] private int _maxCount;

    private WaitForSeconds _wait;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        _wait = new WaitForSeconds(_delay);

        for (int i = 0; i < _maxCount; i++)
        {
            SpawnEnemyToRandomPoint();

            yield return _wait;
        }
    }

    private void SpawnEnemyToRandomPoint()
    {
        if (_enemyPrefab == null || _points == null || _points.Length == 0)
            return;

        int randomIndex = Random.Range(0, _points.Length);

        Enemy enemy = Instantiate(_enemyPrefab, _points[randomIndex].transform.position, Quaternion.identity);

        enemy.Initialize(GetRandomDirection());
    }

    private Vector3 GetRandomDirection()
    {
        int randomIndex = Random.Range(0, Directions.Length);

        return Directions[randomIndex];
    }
}
