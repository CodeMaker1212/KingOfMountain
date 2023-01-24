using UnityEngine;
using Zenject;

namespace KingOfMountain.DependencyBoot
{
    public class AnimationInstaller : MonoInstaller
    {
        [SerializeField] private Animator _playerAnimator;
        [SerializeField] private Animator _enemyAnimator;
        [SerializeField] private Animation _startScreenAnimation;

        public override void InstallBindings()
        {
            Container.BindInstance(_startScreenAnimation)
                     .WhenInjectedInto<StartScreen>();

            Container.BindInstance(_playerAnimator)
                     .WhenInjectedInto(typeof(Player),
                                       typeof(PlayerJumpingBehavior));

            Container.BindInstance(_enemyAnimator)
                     .WhenInjectedInto<EnemyJumpingBehavior>();
        }
    }
}