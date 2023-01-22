using UnityEngine;
using Zenject;

namespace KingOfMountain
{
    public class Ladder : MonoBehaviour
    {
        private Vector3 _stepBlockOffset = new Vector3(0, 5, 5);
        private GameObject _stepsBlock;
        private GameEventsProvider _eventsProvider;

        [Inject]
        private void Construct(GameObject stepsBlock , GameEventsProvider eventsProvider) 
        {
            _stepsBlock = stepsBlock;
            _eventsProvider = eventsProvider;

            _eventsProvider.OnEventPublished += (gameEvent) =>
            {
                if (gameEvent == GameEvent.LadderUpdateTriggered)
                    UpdateStepsBlock();
            };
        }

        private void UpdateStepsBlock()
        {
            _stepsBlock.transform.localPosition =
                _stepsBlock.transform.localPosition + _stepBlockOffset;

            _eventsProvider.PublishEvent(GameEvent.OnLadderUpdated);
        }
    }
}