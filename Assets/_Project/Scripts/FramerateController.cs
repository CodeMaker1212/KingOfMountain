using UnityEngine;

namespace KingOfMountain
{
    public class FramerateController : MonoBehaviour
    {
        private void Start() => Application.targetFrameRate = 60;
    }
}