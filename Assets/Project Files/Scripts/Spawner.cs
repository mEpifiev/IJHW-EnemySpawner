using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<SpawnPoint> _spawnPoints;
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
        if (_spawnPoints == null || _spawnPoints.Count == 0)
            return;

        int randomIndex = Random.Range(0, _spawnPoints.Count);

        _spawnPoints[randomIndex].CreateEnemy();
    }
}
