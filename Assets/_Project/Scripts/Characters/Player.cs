using KingOfMountain.Events;
using UnityEngine;
using Zenject;

namespace KingOfMountain
{
    public class Player : MonoBehaviour
    {
        private AnimationController _animationController;       
        private ParticleSystem _explosionEffect;

        [Inject]
        private void Construct(Animator animator, ParticleSystem explisionEffect)
        {
            _animationController = new AnimationController(animator);
            _explosionEffect = explisionEffect;

            GameEventsBus.Subscribe(GameEvent.OnPlayerOutsideLadder, Fall);
            GameEventsBus.Subscribe(GameEvent.OnPlayerCollidedEnemy, Explode);
        }
        
        private void Fall()
        {
            _animationController.ChangeState("Falling");

            GameEventsBus.Publish(GameEvent.OnPlayerFall);
        }

        private void Explode()
        {
            _explosionEffect.transform.SetParent(null);
            _explosionEffect.Play();

            gameObject.SetActive(false);

            GameEventsBus.Publish(GameEvent.OnPlayerExploded);
        }
    }
}