using Zenject;

namespace KingOfMountain.DependencyBoot
{
    public class TagsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInstance("Enemy")
                     .WithId("EnemyTag");

            Container.BindInstance("Step")
                     .WithId("StepTag");

            Container.BindInstance("LadderUpdateTrigger")
                     .WithId("LadderUpdateTriggerTag");
        }
    }
}