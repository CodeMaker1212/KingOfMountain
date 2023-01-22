using UnityEngine;
using Zenject;

namespace KingOfMountain
{
    public class CameraBehavior : MonoBehaviour
    {
        [Inject(Id = "PlayerBody")]
        private Transform _playerTransform;

        private ShakingEffect _shakingEffect;
        private GameEventsProvider _eventsProvider;
        private float _speed = 7;
        private Vector3 _offset = new Vector3(0, 5.83f, -3.44f);

        [Inject]
        private void Construct(ShakingEffect shakingEffect, GameEventsProvider eventsProvider)
        {
            _shakingEffect = shakingEffect;
            _eventsProvider = eventsProvider;

            _eventsProvider.OnEventPublished += (_) =>
            {
                switch (_)
                {
                    case GameEvent.OnPlayerOutsideLadder:
                        enabled = false;
                        break;

                    case GameEvent.OnPlayerExploded:
                        enabled = false;
                        _shakingEffect.Play();
                        break;
                }           
            };
        }

        private void LateUpdate()
        {
            var targetPosition = new Vector3(transform.position.x,
                                             _playerTransform.position.y,
                                             _playerTransform.transform.position.z) + _offset;

            transform.position = Vector3.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);
        }
    }
}