using UnityEngine;
using Zenject;

namespace KingOfMountain.DependencyBoot
{
    public class EffectsInstaller : MonoInstaller
    {
        [SerializeField] private ShakingEffect _shakingEffect;
        [SerializeField] private ParticleSystem _explosionEffect;

        public override void InstallBindings()
        {
            Container.BindInstance(_shakingEffect)
                     .WhenInjectedInto<CameraBehavior>();

            Container.BindInstance(_explosionEffect);
        }
    }
}