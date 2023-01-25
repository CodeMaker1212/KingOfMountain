using KingOfMountain.Events;
using UnityEngine.UI;
using Zenject;

namespace KingOfMountain
{
    public class HUD : UIElement, IScoreDisplay
    {       
        private Text _score;

        [Inject]
        private void Construct(Text score)
        {
            _score = score;

            GameEventsBus.Subscribe(GameEvent.OnPlayerDie, Deactivate);       
        }      
    
        public void DisplayScore(Score score)
        {
            _score.text = score.CurrentValue.ToString();
        }
    }
}