using UnityEngine;

namespace KingOfMountain
{
    [CreateAssetMenu(fileName = "NewEnemySpawnerConfig")]
    public class EnemySpawnerConfig : ScriptableObject
    {
        [SerializeField]
        private Enemy[] _prefabs;

        [Tooltip("Начальный промежуток времени между спавном (в секундах)")]
        [SerializeField]
        [Range(1f, 3f)]
        private float _startSpawnInterval;

        [Tooltip("Минимальный промежуток времени между спавном (в секундах)")]
        [SerializeField]
        [Range(0f, 1f)]
        private float _minSpawnInterval;

        [Tooltip("Вычитаемое значение временного промежутка между спавном")]
        [SerializeField]
        [Range(0f, 0.1f)]
        private float _spawnIntervalDecreaser;   

        public Enemy[] Prefabs => _prefabs;

        /// <summary>
        /// Начальный промежуток времени между спавном (в секундах).
        /// </summary>
        public float StartSpawnInterval => _startSpawnInterval;

        /// <summary>
        /// Минимальный промежуток времени между спавном (в секундах).
        /// </summary>
        public float MinSpawnInterval => _minSpawnInterval;

        /// <summary>
        /// Вычитаемое значение временного промежутка между спавном.
        /// </summary>
        public float SpawnIntervalDecreaser => _spawnIntervalDecreaser;
    }
}