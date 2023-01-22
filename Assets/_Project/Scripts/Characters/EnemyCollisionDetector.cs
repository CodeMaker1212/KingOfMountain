using UnityEngine;
using Zenject;

namespace KingOfMountain
{
    public class EnemyCollisionDetector : MonoBehaviour
    {
        [Inject(Id = "EnemyTag")]
        private string _enemyTag;

        [Inject]
        private GameEventsProvider _eventsProvider;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(_enemyTag))
                _eventsProvider.PublishEvent(GameEvent.OnPlayerCollidedEnemy);              
        }
    }
}