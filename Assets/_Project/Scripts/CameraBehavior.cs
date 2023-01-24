using UnityEngine;
using Zenject;
using KingOfMountain.Events;

namespace KingOfMountain
{
    public class CameraBehavior : MonoBehaviour
    {
        [Inject(Id = "PlayerBody")]
        private Transform _playerTransform;

        private ShakingEffect _shakingEffect;
        private float _speed = 7;
        private Vector3 _offset = new Vector3(0, 5.83f, -3.44f);

        [Inject]
        private void Construct(ShakingEffect shakingEffect)
        {
            _shakingEffect = shakingEffect;

            GameEventsBus.Subscribe(GameEvent.OnPlayerOutsideLadder, Disable);
            GameEventsBus.Subscribe(GameEvent.OnPlayerDie, Disable);
            GameEventsBus.Subscribe(GameEvent.OnPlayerDie, PlayShakingEffect);        
        }

        private void Disable() => enabled = false;

        private void PlayShakingEffect() => _shakingEffect.Play();

        private void LateUpdate()
        {
            var targetPosition = new Vector3(transform.position.x,
                                             _playerTransform.position.y,
                                             _playerTransform.transform.position.z) + _offset;

            transform.position = Vector3.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);
        }
    }
}