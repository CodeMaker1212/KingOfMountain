using UnityEngine;
using Zenject;

namespace KingOfMountain.DependencyBoot
{
    public class FactoriesInstaller : MonoInstaller
    {
        [SerializeField] private SimplePrefabFactory _simplePrefabFactory;

        public override void InstallBindings()
        {
            Container.BindInstance(_simplePrefabFactory);
        }
    }
}