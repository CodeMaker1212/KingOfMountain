using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace KingOfMountain.DependencyBoot
{
    public class UIInstaller : MonoInstaller
    {
        [SerializeField] private GameOverScreen _gameOverScreen;
        [SerializeField] private HUD _hud;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _startButton;
        [SerializeField] private Text _scoreResult;
        [SerializeField] private Text _bestScore;
        [SerializeField] private Text _scoreHUD;

        public override void InstallBindings()
        {
            Container.Bind<IScoreDisplay>()
                     .FromInstance(_hud)
                     .WhenInjectedInto<ScoreBank>();

            Container.Bind<IScoreDisplay>()
                     .FromInstance(_gameOverScreen)
                     .WhenInjectedInto<GameOverHandler>();

            Container.BindInstance(_gameOverScreen)
                     .AsTransient();

            Container.BindInstance(_startButton)
                     .WhenInjectedInto<StartScreen>();

            Container.BindInstance(_restartButton)
                     .WhenInjectedInto<GameOverScreen>();

            Container.Bind<Text>()
                     .WithId("ScoreResultText").FromInstance(_scoreResult)
                     .WhenInjectedInto<GameOverScreen>();

            Container.Bind<Text>()
                     .WithId("BestScoreText")
                     .FromInstance(_bestScore)
                     .WhenInjectedInto<GameOverScreen>();

            Container.BindInstance(_scoreHUD)
                     .WhenInjectedInto<HUD>();
        }
    }
}