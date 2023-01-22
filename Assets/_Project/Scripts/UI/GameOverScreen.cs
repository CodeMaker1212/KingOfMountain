using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Zenject;

namespace KingOfMountain
{
    public class GameOverScreen : MonoBehaviour, IScoreDisplay
    {
        [Inject(Id = "ScoreResultText")] private Text _scoreResult;
        [Inject(Id = "BestScoreText")] private Text _bestScore;

        private Button _restartButton;  
        private ScoreBank _scoreBank;

        [Inject]
        private void Construct(Button restartButton, ScoreBank scoreBank)
        {
            _restartButton = restartButton;
            _scoreBank = scoreBank;
        }

        private void Start()
        {
            _restartButton.onClick.AddListener(HandleRestartButtonClick);

            DisplayScore(_scoreBank.ScoreValues);
        }

        private void HandleRestartButtonClick()
        {
            SceneManager.LoadScene(0);
        }

        public void DisplayScore(Score score)
        {
            _scoreResult.text = $"Score: {score.CurrentValue}";
            _bestScore.text = $"Best: {score.BestValue}";
        }
    }
}