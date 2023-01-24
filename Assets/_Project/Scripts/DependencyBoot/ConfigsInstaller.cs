using UnityEngine;
using Zenject;

namespace KingOfMountain.DependencyBoot
{
    public class ConfigsInstaller : MonoInstaller
    {
        [SerializeField] private EnemySpawnerConfig _enemySpawnerConfig;

        public override void InstallBindings()
        {
            Container.BindInstance(_enemySpawnerConfig);
        }
    }
}