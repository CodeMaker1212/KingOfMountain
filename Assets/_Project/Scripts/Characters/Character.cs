using UnityEngine;

namespace KingOfMountain.Characters
{
    public abstract class Character : MonoBehaviour, ISwitchable
    {
        public void Activate() => gameObject.SetActive(true);

        public abstract void Deactivate();

        protected abstract void Die();
    }
}