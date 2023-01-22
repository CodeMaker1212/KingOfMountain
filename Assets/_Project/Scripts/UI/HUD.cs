using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace KingOfMountain
{
    public class HUD : MonoBehaviour
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
                    case GameEvent.OnPlayerExploded: ClearPointDisplay();
                    break;
                }            
            };
        }

        public void DisplayCurrentScore(int value) => _score.text = value.ToString();

        private void ClearPointDisplay() => _score.text = string.Empty;
    }
}