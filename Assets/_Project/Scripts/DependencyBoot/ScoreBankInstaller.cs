using UnityEngine;
using Zenject;

namespace KingOfMountain.DependencyBoot
{
    public class ScoreBankInstaller : MonoInstaller
    {
        [SerializeField] private ScoreBank _scoreBank;

        public override void InstallBindings()
        {
            Container.Bind<ScoreBank>()
                     .FromInstance(_scoreBank)
                     .AsSingle();
        }
    }
}