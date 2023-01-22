using System.Collections;
using UnityEngine;
using Zenject;

namespace KingOfMountain
{
    public class EnemySpawner : MonoBehaviour
    {
        private SimplePrefabFactory _prefabFactory;
        private Transform[] _spawnPoints;
        private EnemySpawnerConfig _config;
        private GameEventsProvider _eventsProvider;     
        private Coroutine _spawnCoroutine;
        private Vector3 _shiftPoint = new Vector3(0, 1, 1);
        private float _currentSpawnTimeInterval;

        [Inject]
        private void Construct(SimplePrefabFactory prefabFactory, Transform[] spawnPoints,
                               EnemySpawnerConfig config, GameEventsProvider eventsProvider)
        {
            _prefabFactory = prefabFactory;
            _spawnPoints = spawnPoints;
            _config = config;
            _eventsProvider = eventsProvider;

            _eventsProvider.OnEventPublished += (gameEvent) =>
            {
                if (gameEvent == GameEvent.OnPlayerOvercameStep)
                {
                    if (_spawnCoroutine == null)
                        StartSpawn();

                    ShiftPosition();

                    CalculateNewSpawnInterval();
                }
            };
        }

        private void Start()
        {
            _currentSpawnTimeInterval = _config.StartSpawnInterval;
        }

        private void OnDisable()
        {
            if (_spawnCoroutine != null)
                StopCoroutine(_spawnCoroutine);
        }

        private void StartSpawn()
        {
            _spawnCoroutine = StartCoroutine(SpawnEnemies());
        }

        private IEnumerator SpawnEnemies()
        {
            while (true)
            {
                var enemy = _prefabFactory.CreatePrefabInstance(_config.Prefabs[0]);
                var spawnPointIndex = Random.Range(0, _spawnPoints.Length);

                enemy.transform.position = _spawnPoints[spawnPointIndex].position;

                yield return new WaitForSeconds(_currentSpawnTimeInterval);
            }
        }

        private void ShiftPosition()
        {
            transform.position += _shiftPoint;
        }

        private void CalculateNewSpawnInterval()
        {
            _currentSpawnTimeInterval -= _config.SpawnIntervalDecreaser;

            if (_currentSpawnTimeInterval < _config.MinSpawnInterval)
                _currentSpawnTimeInterval = _config.MinSpawnInterval;
        }     
    }
}