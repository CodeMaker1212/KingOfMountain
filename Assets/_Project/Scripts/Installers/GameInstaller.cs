using KingOfMountain;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [Header("Characters")]
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Transform _playerBody;

    [Header("GameObjects")]
    [SerializeField] private GameObject _stepsBlock;

    [Header("Effects")]
    [SerializeField] private ShakingEffect _shakingEffect;
    [SerializeField] private ParticleSystem _explosionEffect;  

    [Header("Configs")]
    [SerializeField] private EnemySpawnerConfig _enemySpawnerConfig;

    [Header("Animation")]
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private Animator _enemyAnimator;
    [SerializeField] private Animation _startScreenAnimation;

    [Header("Factories")]
    [SerializeField] private SimplePrefabFactory _simplePrefabFactory; 

    [Header("UI")]
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private HUD _hud;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _startButton;
    [SerializeField] private Text _scoreResult;
    [SerializeField] private Text _bestScore;
    [SerializeField] private Text _scoreHUD;

    [Space]
    [SerializeField] private Transform[] _enemySpawnPoints;
    [SerializeField] private ScoreBank _scoreBank;
    [SerializeField] private ScreenTouchDetector _touchDetector;

    public override void InstallBindings()
    {
        InstallEventsProvider();

        InstallDataServices();

        InstallGameObjects();

        InstallTransforms();

        InstallFactories();

        InstallAnimators();

        InstallConfigs();

        InstallTags();

        InstallEffects();

        InstallScoreBank();

        InstallUI();

        InstallTouchDetector();
    }

    private void InstallEventsProvider()
    {
        Container.Bind<GameEventsProvider>().AsSingle();
    }

    private void InstallDataServices()
    {
        Container.Bind<ISavableDataService>().To<JsonDataService>().AsSingle();
    }

    private void InstallGameObjects()
    {
        Container.BindInstance(_stepsBlock).WhenInjectedInto<Ladder>();      
    }

    private void InstallTransforms()
    {
        Container.BindInstance(_enemySpawnPoints).WhenInjectedInto<EnemySpawner>();
        Container.Bind<Transform>().WithId("PlayerBody").FromInstance(_playerBody).WhenInjectedInto<CameraBehavior>();
    }
 
    private void InstallFactories()
    {
        Container.BindInstance(_simplePrefabFactory);
    }

    private void InstallAnimators()
    {
        Container.BindInstance(_startScreenAnimation).WhenInjectedInto<StartScreen>();
        Container.BindInstance(_playerAnimator).WhenInjectedInto(typeof(Player), typeof(PlayerJumpingBehavior));
        Container.BindInstance(_enemyAnimator).WhenInjectedInto<EnemyJumpingBehavior>();
    }

    private void InstallConfigs()
    {
        Container.BindInstance(_enemySpawnerConfig);
    }

    private void InstallTags()
    {
        Container.BindInstance(_enemy.tag).WithId("EnemyTag");
        Container.BindInstance("Step").WithId("StepTag");
        Container.BindInstance("LadderUpdateTrigger").WithId("LadderUpdateTriggerTag");
    }

    private void InstallEffects()
    {
        Container.BindInstance(_shakingEffect).WhenInjectedInto<CameraBehavior>();
        Container.BindInstance(_explosionEffect);
    } 

    private void InstallScoreBank()
    {
        Container.Bind<ScoreBank>().FromInstance(_scoreBank).AsSingle();
    }

    private void InstallUI()
    {
        Container.Bind<IScoreDisplay>().FromInstance(_hud).WhenInjectedInto<ScoreBank>();
        Container.Bind<IScoreDisplay>().FromInstance(_gameOverScreen).WhenInjectedInto<GameOverHandler>();
        Container.BindInstance(_gameOverScreen).AsTransient();
        Container.BindInstance(_startButton).WhenInjectedInto<StartScreen>();
        Container.BindInstance(_restartButton).WhenInjectedInto<GameOverScreen>();
        Container.Bind<Text>().WithId("ScoreResultText").FromInstance(_scoreResult).WhenInjectedInto<GameOverScreen>();
        Container.Bind<Text>().WithId("BestScoreText").FromInstance(_bestScore).WhenInjectedInto<GameOverScreen>();
        Container.BindInstance(_scoreHUD).WhenInjectedInto<HUD>();        
    }

    private void InstallTouchDetector()
    {
        Container.BindInstance(_touchDetector).AsSingle();
    }
}