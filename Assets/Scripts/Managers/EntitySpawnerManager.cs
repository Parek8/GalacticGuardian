using UnityEngine;

internal sealed class EntitySpawnerManager : MonoBehaviour
{
    [field: SerializeField] GameObject EnemyTemporaryPrefab;

    internal static EntitySpawnerManager EntitySpawnerManagerInstance => _entitySpawnerManagerInstance;
    private static EntitySpawnerManager _entitySpawnerManagerInstance;

    private void Awake()
    {
        if (_entitySpawnerManagerInstance == null)
            _entitySpawnerManagerInstance = this;
    }

    public void StartNewWave()
    {
        int _entityCount = Random.Range(2, 20);

        for (int i = 0; i < _entityCount; i++)
        {
            Instantiate(EnemyTemporaryPrefab, new Vector2((Mathf.Cos(Random.Range(0f, 360f))), (Mathf.Sin(Random.Range(0f, 360f)))), Quaternion.identity);
        }
    }
}