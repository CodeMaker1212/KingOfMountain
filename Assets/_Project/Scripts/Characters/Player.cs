using KingOfMountain.Events;
using UnityEngine;
using Zenject;

namespace KingOfMountain.Characters
{
    public class Player : Character
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
        }

        private void Explode()
        {
            _explosionEffect.transform.SetParent(null);
            _explosionEffect.Play(); 
            
            Die();
        }

        // Called by AnimationEvent.
        protected override void Die()
        {
            Deactivate();

            GameEventsBus.Publish(GameEvent.OnPlayerDie);
        }

        public override void Deactivate()
        {
            gameObject.SetActive(false);
        }
    }
}