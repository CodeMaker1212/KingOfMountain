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

            GameEventsBus.Subscribe(GameEvent.OnPlayerDie, Disable);       
        }      
    
        public void DisplayScore(Score score)
        {
            _score.text = score.CurrentValue.ToString();
        }

        private void Disable() => gameObject.SetActive(false);

    }
}