using Zenject;
using KingOfMountain.Events;

namespace KingOfMountain.DependencyBoot
{
    public class EventsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<GameEventsBus>()
                     .AsSingle()
                     .NonLazy();
        }
    }
}