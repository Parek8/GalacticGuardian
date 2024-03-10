using System.Collections;
using System.Collections.Generic;
using UnityEngine;


internal sealed class EntitySpawnerManager : MonoBehaviour
{
    [field: SerializeField] List<GameObject> EnemyTemporaryPrefabs;
    [field: SerializeField] float MinWaveSpawnDelay;
    [field: SerializeField] float MaxWaveSpawnDelay;

    internal static EntitySpawnerManager EntitySpawnerManagerInstance => _entitySpawnerManagerInstance;
    private static EntitySpawnerManager _entitySpawnerManagerInstance;

    int _waveCount = 0;
    internal int WaveCount => _waveCount;
    private void Awake()
    {
        if (_entitySpawnerManagerInstance == null)
            _entitySpawnerManagerInstance = this;

        StartCoroutine(StartNewWave());
    }

    internal IEnumerator StartNewWave()
    {
        while (true)
        {
            int _entityCount = Random.Range(2, 10);
            float _range = Random.Range(15f, 25f);

            for (int i = 0; i < _entityCount; i++)
            {
                float _angle = Random.Range(0, Mathf.PI * 2);
                Instantiate(EnemyTemporaryPrefabs[UnityEngine.Random.Range(0, EnemyTemporaryPrefabs.Count)], (Vector2)GameManager.GameManagerInstance.PlayerTransform.position + (new Vector2((Mathf.Cos(_angle)), (Mathf.Sin(_angle))) * _range), Quaternion.identity);
            }
            _waveCount++;
            yield return new WaitForSeconds(Random.Range(MinWaveSpawnDelay, MaxWaveSpawnDelay));
        }
    }
}