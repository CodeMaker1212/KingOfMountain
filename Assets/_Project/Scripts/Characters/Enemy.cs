using UnityEngine;

namespace KingOfMountain
{
    public class Enemy : MonoBehaviour
    {
        private const float _lifeTimeInSeconds = 12.0f;

        private void Start() => Invoke(nameof(DestroyInstance), _lifeTimeInSeconds);

        private void DestroyInstance() => Destroy(gameObject);
    }
}