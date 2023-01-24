using Zenject;

namespace KingOfMountain.DependencyBoot
{
    public class EventsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<GameEventsProvider>()
                     .AsSingle();
        }
    }
}