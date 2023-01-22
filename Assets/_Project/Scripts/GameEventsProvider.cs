using System;

namespace KingOfMountain
{
    public class GameEventsProvider
    {
        public event Action<GameEvent> OnEventPublished;

        public void PublishEvent(GameEvent gameEvent)
        {
            OnEventPublished?.Invoke(gameEvent);
        }
    }

    public enum GameEvent 
    { 
        OnPlayerOvercameStep,
        LadderUpdateTriggered,
        OnLadderUpdated, 
        OnPlayerOutsideLadder,
        OnPlayerFall,
        OnPlayerCollidedEnemy,
        OnPlayerExploded,
    }
}