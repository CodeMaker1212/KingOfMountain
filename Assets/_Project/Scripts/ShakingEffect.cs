using UnityEngine;

namespace KingOfMountain
{
    public class ShakingEffect : MonoBehaviour
    {
        private const float _force = 0.5f;
        private const float _duration = 0.3f;
        private Vector3 _initialPosition;

        private void OnEnable()
        {
            _initialPosition = gameObject.transform.position;
        }

        private void OnDisable()
        {
            gameObject.transform.position = _initialPosition;
        }

        private void Update()
        {
            transform.position = _initialPosition + (Random.insideUnitSphere * _force);
        }

        public void Play()
        {
            enabled = true;

            Invoke(nameof(Stop), _duration);
        }

        private void Stop() => enabled = false;
    }
}