using KingOfMountain.Events;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace KingOfMountain
{
    public class HUD : MonoBehaviour, IScoreDisplay
    {       
        private Text _score;

        [Inject]
        private void Construct(Text score)
        {
            _score = score;

            GameEventsBus.Subscribe(GameEvent.OnPlayerFall, ClearScoreDisplay);
            GameEventsBus.Subscribe(GameEvent.OnPlayerExploded, ClearScoreDisplay);       
        }      

        private void ClearScoreDisplay() => _score.text = string.Empty;

        public void DisplayScore(Score score) =>     
            _score.text = score.CurrentValue.ToString();
        
    }
}