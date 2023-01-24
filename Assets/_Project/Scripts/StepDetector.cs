using KingOfMountain.Events;
using UnityEngine;
using Zenject;

namespace KingOfMountain
{
    public class StepDetector : MonoBehaviour
    {
        [Inject(Id = "StepTag")]
        private string _stepTag;

        [Inject(Id = "LadderUpdateTriggerTag")]
        private string _ladderUpdateTriggerTag;


        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag(_stepTag))
                GameEventsBus.Publish(GameEvent.OnPlayerOvercameStep);

            if (other.CompareTag(_ladderUpdateTriggerTag))
            {
                GameEventsBus.Publish(GameEvent.OnPlayerOvercameStep);
                GameEventsBus.Publish(GameEvent.LadderUpdateTriggered);
            }
        }
    }
}