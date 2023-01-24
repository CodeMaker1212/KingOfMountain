using System.Collections;
using UnityEngine;
using Zenject;
using KingOfMountain.Events;

namespace KingOfMountain
{
    public class EnemySpawner : MonoBehaviour
    {
        private SimplePrefabFactory _prefabFactory;
        private Transform[] _spawnPoints;
        private EnemySpawnerConfig _config;  
        private Coroutine _spawnCoroutine;
        private Vector3 _shiftPoint = new Vector3(0, 1, 1);
        private float _currentSpawnTimeInterval;

        [Inject]
        private void Construct(SimplePrefabFactory prefabFactory,
                               Transform[] spawnPoints,
                               EnemySpawnerConfig config)
        {
            _prefabFactory = prefabFactory;
            _spawnPoints = spawnPoints;
            _config = config;

            GameEventsBus.Subscribe(GameEvent.OnPlayerOvercameStep, StartSpawn);
            GameEventsBus.Subscribe(GameEvent.OnPlayerOvercameStep, ShiftPosition);
            GameEventsBus.Subscribe(GameEvent.OnPlayerOvercameStep, CalculateNewSpawnInterval);
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
            if (_spawnCoroutine != null) return;

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