using UnityEngine;
using Zenject;

namespace KingOfMountain
{
    public class Player : MonoBehaviour
    {
        private AnimationController _animationController;       
        private ParticleSystem _explosionEffect;
        private GameEventsProvider _eventsProvider;

        [Inject]
        private void Construct(Animator animator, ParticleSystem explisionEffect, GameEventsProvider eventsProvider)
        {
            _animationController = new AnimationController(animator);
            _explosionEffect = explisionEffect;
            _eventsProvider = eventsProvider;

            _eventsProvider.OnEventPublished += (_) =>
            {
                switch (_)
                {
                    case GameEvent.OnPlayerOutsideLadder: Fall(); break;
                    case GameEvent.OnPlayerCollidedEnemy: Explode(); break;
                }
            };
        }
        
        private void Fall()
        {
            _animationController.ChangeState("Falling");

            _eventsProvider.PublishEvent(GameEvent.OnPlayerFall);
        }

        private void Explode()
        {
            _explosionEffect.transform.SetParent(null);
            _explosionEffect.Play();

            gameObject.SetActive(false);

            _eventsProvider.PublishEvent(GameEvent.OnPlayerExploded);
        }
    }
}