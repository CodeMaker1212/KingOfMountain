using UnityEngine;

namespace KingOfMountain
{
    [CreateAssetMenu(fileName = "NewJumpingConfig")]
    public class JumpingConfig : ScriptableObject
    {
        [SerializeField]
        private Vector3 _straightJumpOffset;

        [SerializeField]
        private Vector3 _leftJumpOffset;

        [SerializeField]
        private Vector3 _rightJumpOffset;

        [SerializeField]
        [Range(0, 15)] 
        private int _straightJumpSpeed;

        [SerializeField]
        [Range(0, 15)] 
        private int _sideJumpSpeed;

        public Vector3 StraightJumpOffset => _straightJumpOffset;
        public Vector3 LeftJumpOffset => _leftJumpOffset;
        public Vector3 RightJumpOffset => _rightJumpOffset;
        public float StraightJumpSpeed => _straightJumpSpeed;
        public float SideJumpSpeed => _sideJumpSpeed;
    }
}