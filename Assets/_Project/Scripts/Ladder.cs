using UnityEngine;
using Zenject;
using KingOfMountain.Events;

namespace KingOfMountain
{
    public class Ladder : MonoBehaviour
    {
        private Vector3 _stepBlockOffset = new Vector3(0, 5, 5);
        private GameObject _stepsBlock;

        [Inject]
        private void Construct(GameObject stepsBlock) 
        {
            _stepsBlock = stepsBlock;

            GameEventsBus.Subscribe(GameEvent.LadderUpdateTriggered, UpdateStepsBlock);
        }

        private void UpdateStepsBlock()
        {
            _stepsBlock.transform.localPosition =
                _stepsBlock.transform.localPosition + _stepBlockOffset;

            GameEventsBus.Publish(GameEvent.OnLadderUpdated);
        }
    }
}