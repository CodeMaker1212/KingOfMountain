using UnityEngine;
using System;
using Zenject;
using KingOfMountain.Events;

namespace KingOfMountain
{
    public class ScoreBank : MonoBehaviour
    {
        private IScoreDisplay _scoreDisplay;
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
        private void Construct(IScoreDisplay scoreDiplay, ISavableDataService dataService)
        {
            _scoreDisplay = scoreDiplay;         

            _dataService = dataService;

            GameEventsBus.Subscribe(GameEvent.OnPlayerOvercameStep, AddScore);
            GameEventsBus.Subscribe(GameEvent.OnPlayerDie, SaveData);

            RestoreData();
        }

        public void AddScore()
        {
            CurrentScore++;

            _scoreDisplay.DisplayScore(ScoreValues);
        }

        public void SaveData()
        {
            _dataService.Save("BestScore", _savableData);
        }
           
        private void RestoreData()
        {
            _savableData = _dataService.Load<SavableData>("BestScore");
            _savableData ??= new SavableData();
        }           

        private void OnApplicationQuit() => SaveData();


        [Serializable]
        private class SavableData
        {
            public int BestScore;
        }
    }
}