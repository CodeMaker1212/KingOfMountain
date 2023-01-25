using UnityEngine;

namespace KingOfMountain
{
    public class UIElement : MonoBehaviour, ISwitchable
    {
        public void Activate() => gameObject.SetActive(true);

        public void Deactivate() => gameObject.SetActive(false);

    }
}