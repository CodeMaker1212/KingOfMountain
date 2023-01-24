using UnityEngine;
using Zenject;

namespace KingOfMountain.DependencyBoot
{
    public class InputServicesInstaller : MonoInstaller
    {
        [SerializeField] private ScreenTouchDetector _touchDetector;

        public override void InstallBindings()
        {
            Container.BindInstance(_touchDetector)
                     .AsSingle();
        }
    }
}