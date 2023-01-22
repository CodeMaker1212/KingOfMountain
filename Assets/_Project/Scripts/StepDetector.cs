using UnityEngine;
using Zenject;

namespace KingOfMountain
{
    public class StepDetector : MonoBehaviour
    {
        private GameEventsProvider _eventsProvider;

        [Inject(Id = "StepTag")]
        private string _stepTag;

        [Inject(Id = "LadderUpdateTriggerTag")]
        private string _ladderUpdateTriggerTag;

        [Inject]
        private void Construct(GameEventsProvider eventsProvider)
        {
            _eventsProvider = eventsProvider;
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag(_stepTag))
                _eventsProvider.PublishEvent(GameEvent.OnPlayerOvercameStep);

            if (other.CompareTag(_ladderUpdateTriggerTag))
            {
                _eventsProvider.PublishEvent(GameEvent.OnPlayerOvercameStep);
                _eventsProvider.PublishEvent(GameEvent.LadderUpdateTriggered);
            }
        }
    }
}