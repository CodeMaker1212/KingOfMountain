using Zenject;
using KingOfMountain.SaveLoad;

namespace KingOfMountain.DependencyBoot
{
    public class DataServicesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {

#if UNITY_ANDROID

            Container.Bind<SavableDataService>()
                    .To<JsonDataService>()
                    .AsSingle();
#else
           Container.Bind<SavableDataService>()
                    .To<BinaryDataService>()
                    .AsSingle();
#endif
        }
    }
}