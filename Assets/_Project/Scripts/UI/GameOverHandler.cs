using UnityEngine;
using Zenject;

namespace KingOfMountain
{
    public class GameOverHandler : MonoBehaviour
    {
        private GameOverScreen _gameOverScreen;
        private GameEventsProvider _eventsProvider;

        private float _startScreenEnablingDelay = 0.8f;

        [Inject]
        private void Construct(GameOverScreen gameOverScreen, GameEventsProvider eventsProvider)
        {
            _gameOverScreen = gameOverScreen;
            _eventsProvider = eventsProvider;

            _eventsProvider.OnEventPublished += (gameEvent) =>
            {
                switch (gameEvent)
                {
                    case GameEvent.OnPlayerExploded:
                    case GameEvent.OnPlayerFall:

                        Invoke(nameof(EnableGameOverScreen), _startScreenEnablingDelay);

                        break;
                }
            };
        }

        private void EnableGameOverScreen()
        {
            _gameOverScreen.gameObject.SetActive(true);
        }
    }
}