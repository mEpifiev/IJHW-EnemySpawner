using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private EnemyTarget _enemyTarget;
    
    public void CreateEnemy()
    {
        Enemy enemy = Instantiate(_enemyPrefab, transform.position, transform.rotation);

        enemy.SetTarget(_enemyTarget);
    }
}
