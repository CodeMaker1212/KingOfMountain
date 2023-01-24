using Zenject;

namespace KingOfMountain.DependencyBoot
{
    public class DataServicesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ISavableDataService>()
                     .To<JsonDataService>()
                     .AsSingle();
        }
    }
}