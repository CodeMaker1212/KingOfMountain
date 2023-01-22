using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace KingOfMountain
{
    public class HUD : MonoBehaviour, IScoreDisplay
    {       
        private Text _score;

        [Inject]
        private void Construct(Text score, GameEventsProvider eventsProvider)
        {
            _score = score;

            eventsProvider.OnEventPublished += (_) =>
            {
                switch (_)
                {
                    case GameEvent.OnPlayerFall:
                    case GameEvent.OnPlayerExploded: ClearScoreDisplay();
                    break;
                }            
            };
        }      

        public void DisplayScore<T>(T value) where T : struct
        {
            
        }

        private void ClearScoreDisplay() => _score.text = string.Empty;

        public void DisplayScore(Score score)
        {
            _score.text = score.CurrentValue.ToString();
        }
    }
}