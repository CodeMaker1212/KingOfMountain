using UnityEngine;
using Zenject;
using KingOfMountain.Events;

namespace KingOfMountain
{
    public class EnemyCollisionDetector : MonoBehaviour
    {
        [Inject(Id = "EnemyTag")]
        private string _enemyTag;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(_enemyTag))
                GameEventsBus.Publish(GameEvent.OnPlayerCollidedEnemy);
        }
    }
}