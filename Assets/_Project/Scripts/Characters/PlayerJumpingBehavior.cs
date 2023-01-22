using UnityEngine;
using Zenject;

namespace KingOfMountain
{
    public class PlayerJumpingBehavior : JumpingBehavior
    {
        private GameEventsProvider _eventsProvider;
        private ScreenTouchDetector _screenTouchDetector;

        [Inject]
        private void Construct(ScreenTouchDetector touchDetector, GameEventsProvider eventsProvider)
        {
            _screenTouchDetector = touchDetector;
            _eventsProvider = eventsProvider;

            _eventsProvider.OnEventPublished += (_) =>
            {
                switch (_)
                {
                    case GameEvent.OnPlayerFall:
                    case GameEvent.OnPlayerExploded: enabled = false; break;
                }
            };      
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
    }
}