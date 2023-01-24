using UnityEngine;

namespace KingOfMountain
{
    public class AnimationController
    {
        private Animator _animator;

        private const float _defaultTransitionDuration = 0.25f;

        private float _transitionDuration;
        private string _currentState;

        public AnimationController(Animator animator)
        {
            _animator = animator;
        }

        public void ChangeState(string newState, bool instantTransition = true)
        {
            _transitionDuration = instantTransition ? 0 : _defaultTransitionDuration;

            if (_currentState == newState)
                _animator.Rebind();

            _animator.CrossFade(newState, _transitionDuration);

            _currentState = newState;
        }
    }
}