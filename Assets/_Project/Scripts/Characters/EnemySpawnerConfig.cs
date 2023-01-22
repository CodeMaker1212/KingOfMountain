using UnityEngine;

namespace KingOfMountain
{
    [CreateAssetMenu(fileName = "NewEnemySpawnerConfig")]
    public class EnemySpawnerConfig : ScriptableObject
    {
        [SerializeField]
        private Enemy[] _prefabs;

        [Tooltip("��������� ���������� ������� ����� ������� (� ��������)")]
        [SerializeField]
        [Range(1f, 3f)]
        private float _startSpawnInterval;

        [Tooltip("����������� ���������� ������� ����� ������� (� ��������)")]
        [SerializeField]
        [Range(0f, 1f)]
        private float _minSpawnInterval;

        [Tooltip("���������� �������� ���������� ���������� ����� �������")]
        [SerializeField]
        [Range(0f, 0.1f)]
        private float _spawnIntervalDecreaser;   

        public Enemy[] Prefabs => _prefabs;

        /// <summary>
        /// ��������� ���������� ������� ����� ������� (� ��������).
        /// </summary>
        public float StartSpawnInterval => _startSpawnInterval;

        /// <summary>
        /// ����������� ���������� ������� ����� ������� (� ��������).
        /// </summary>
        public float MinSpawnInterval => _minSpawnInterval;

        /// <summary>
        /// ���������� �������� ���������� ���������� ����� �������.
        /// </summary>
        public float SpawnIntervalDecreaser => _spawnIntervalDecreaser;
    }
}