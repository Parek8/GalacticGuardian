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

        StartNewWave();
    }

    public void StartNewWave()
    {
        int _entityCount = Random.Range(1, 10);
        float _range = Random.Range(15f, 25f);

        for (int i = 0; i < _entityCount; i++)
        {
            float _angle = Random.Range(0, Mathf.PI * 2);
            Instantiate(EnemyTemporaryPrefab, new Vector2((Mathf.Cos(_angle)), (Mathf.Sin(_angle))) * _range, Quaternion.identity);
        }
    }
}