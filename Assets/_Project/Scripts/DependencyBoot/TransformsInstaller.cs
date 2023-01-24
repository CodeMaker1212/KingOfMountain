using UnityEngine;
using Zenject;

namespace KingOfMountain.DependencyBoot
{
    public class TransformsInstaller : MonoInstaller
    {
        [SerializeField] private Transform _playerBody;
        [SerializeField] private Transform[] _enemySpawnPoints;

        public override void InstallBindings()
        {
            Container.Bind<Transform>()
                     .WithId("PlayerBody")
                     .FromInstance(_playerBody)
                     .WhenInjectedInto<CameraBehavior>();

            Container.BindInstance(_enemySpawnPoints)
                     .WhenInjectedInto<EnemySpawner>();
        }
    }
}