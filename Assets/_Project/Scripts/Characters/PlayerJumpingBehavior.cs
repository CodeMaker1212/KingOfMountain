using KingOfMountain.Events;
using UnityEngine;
using Zenject;

namespace KingOfMountain
{
    public class PlayerJumpingBehavior : JumpingBehavior
    {
        private ScreenTouchDetector _screenTouchDetector;

        [Inject]
        private void Construct(ScreenTouchDetector touchDetector)
        {
            _screenTouchDetector = touchDetector;

            GameEventsBus.Subscribe(GameEvent.OnPlayerFall, Disable);
            GameEventsBus.Subscribe(GameEvent.OnPlayerExploded, Disable);
        }

        private void OnEnable()
        {
            _screenTouchDetector.OnTap += JumpStraight;
            _screenTouchDetector.OnSwipeLeft += JumpLeft;
            _screenTouchDetector.OnSwipeRight += JumpRight;
        }

        private void OnDisable()
        {
            _screenTouchDetector.OnTap -= JumpStraight;
            _screenTouchDetector.OnSwipeLeft -= JumpLeft;
            _screenTouchDetector.OnSwipeRight -= JumpRight;
        }

        private void FixedUpdate()
        {
            UpdatePosition();
        }  
        
        private void Disable() => enabled= false;
    }
}