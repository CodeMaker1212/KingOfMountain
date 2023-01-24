using KingOfMountain.Events;
using UnityEngine;
using Zenject;

namespace KingOfMountain
{
    public class GameOverHandler : MonoBehaviour
    {
        private GameOverScreen _gameOverScreen;

        private float _startScreenEnablingDelay = 0.8f;

        [Inject]
        private void Construct(GameOverScreen gameOverScreen)
        {
            _gameOverScreen = gameOverScreen;        

            GameEventsBus.Subscribe(GameEvent.OnPlayerExploded,
                 () => Invoke(nameof(EnableGameOverScreen), _startScreenEnablingDelay));

            GameEventsBus.Subscribe(GameEvent.OnPlayerFall,
                 () => Invoke(nameof(EnableGameOverScreen), _startScreenEnablingDelay));
        }

        private void EnableGameOverScreen() => 
            _gameOverScreen.gameObject.SetActive(true);
    }    
}