using KingOfMountain.Events;
using System.Collections;
using UnityEngine;

namespace KingOfMountain
{
    public class GroundDetector : MonoBehaviour
    {
        [SerializeField] private LayerMask _ladderMask;

        private float _timeIntervalBetweenRaycast = 0.1f;
        private float _detectionDistance = 0.8f;

        private void OnEnable()
        {
            StartCoroutine(DetectInContiniousMode());
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }

        private IEnumerator DetectInContiniousMode()
        {
            var waiting = new WaitForSeconds(_timeIntervalBetweenRaycast);

            while (enabled)
            {
                TryFindGround();

                yield return waiting;
            }
        }

        private void TryFindGround()
        {
             var colliders = Physics.OverlapSphere(transform.position, _detectionDistance, _ladderMask);

             if (colliders.Length > 0) return;

             GameEventsBus.Publish(GameEvent.OnPlayerOutsideLadder);

             enabled = false;
        }
    }
}