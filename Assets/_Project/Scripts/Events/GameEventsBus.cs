using System.Collections.Generic;
using UnityEngine.Events;

namespace KingOfMountain.Events
{
    public class GameEventsBus
    {
        private static readonly IDictionary<GameEvent, UnityEvent> _events =
                             new Dictionary<GameEvent, UnityEvent>();

        public static void Subscribe(GameEvent interestEvent, UnityAction listener)
        {
            if (_events.TryGetValue(interestEvent, out UnityEvent thisEvent))
            {
                thisEvent.AddListener(listener);
            }              
            else
            {
                thisEvent = new UnityEvent();
                thisEvent.AddListener(listener);
                _events.Add(interestEvent, thisEvent);
            }
        }

        public static void Unsubscribe(GameEvent notInterestEvent, UnityAction listener)
        {
            if (_events.TryGetValue(notInterestEvent, out UnityEvent thisEvent))
                thisEvent. RemoveListener(listener);
        }

        public static void Publish(GameEvent gameEvent)
        {
            if (_events.TryGetValue(gameEvent, out UnityEvent thisEvent))
                thisEvent.Invoke();
        }
    }

    public enum GameEvent
    { 
        OnPlayerOvercameStep,
        LadderUpdateTriggered,
        OnLadderUpdated, 
        OnPlayerOutsideLadder,
        OnPlayerCollidedEnemy,
        OnPlayerDie,
    }
}