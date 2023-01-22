using UnityEngine;
using System;
using Zenject;

namespace KingOfMountain
{
    public class ScoreBank : MonoBehaviour
    {
        private IScoreDisplay _scoreDisplay;
        private GameEventsProvider _eventsProvider;
        private ISavableDataService _dataService;
        private SavableData _savableData;
        private int _currentScore;

        public int BestScore => _savableData.BestScore;

        public int CurrentScore
        {
            get => _currentScore;
            private set
            {
                _currentScore = Mathf.Clamp(value, 0, int.MaxValue);

                if (_currentScore > _savableData.BestScore)
                    _savableData.BestScore = _currentScore;
            }
        }

        public Score ScoreValues => new Score (CurrentScore, BestScore);

        [Inject] 
        private void Construct(IScoreDisplay scoreDiplay, GameEventsProvider eventsProvider, ISavableDataService dataService)
        {
            _scoreDisplay = scoreDiplay;
            _eventsProvider = eventsProvider;

            _eventsProvider.OnEventPublished += (gameEvent) =>
            {
                switch (gameEvent)
                {
                    case GameEvent.OnPlayerOvercameStep: AddScore(); break;
                    case GameEvent.OnPlayerFall:
                    case GameEvent.OnPlayerExploded: SaveData(); break;
                }
            };

            _dataService = dataService;

            RestoreData();
        }

        private void RestoreData()
        {
            _savableData = _dataService.Load<SavableData>("BestScore");
            _savableData ??= new SavableData();
        }

        private void OnApplicationQuit()
        {
            SaveData();
        }

        public void AddScore()
        {
            CurrentScore++;

            _scoreDisplay.DisplayScore(ScoreValues);
        }

        public void SaveData() => _dataService.Save("BestScore", _savableData);
      
   
        [Serializable]
        private class SavableData
        {
            public int BestScore;
        }
    }
}