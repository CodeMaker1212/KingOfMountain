using UnityEngine;
using Zenject;

namespace KingOfMountain.DependencyBoot
{
    public class GameObjectsInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _stepsBlock;

        public override void InstallBindings()
        {
            Container.BindInstance(_stepsBlock)
                     .WhenInjectedInto<Ladder>();
        }
    }
}