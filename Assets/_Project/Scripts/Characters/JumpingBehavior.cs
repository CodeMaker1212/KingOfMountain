using UnityEngine;

namespace KingOfMountain
{
    [RequireComponent(typeof(Animator))]

    public abstract class JumpingBehavior : MonoBehaviour
    {
        [SerializeField] protected JumpingConfig config;
        protected AnimationController _animationController;

        protected const string _straightAnimationJumpName = "StraightJump";
        protected const string _sideJumpAnimationName = "SideJump";

        protected Vector3 nextPosition;
        protected float jumpSpeed;

        protected virtual void Awake()
        {
            _animationController =
                new AnimationController(GetComponent<Animator>());
        }

        public void JumpStraight()
        {
            nextPosition += config.StraightJumpOffset;
            jumpSpeed = config.StraightJumpSpeed;
            _animationController.ChangeState(_straightAnimationJumpName);
        }

        public void JumpLeft()
        {
            nextPosition += config.LeftJumpOffset;
            jumpSpeed = config.SideJumpSpeed;
            _animationController.ChangeState(_sideJumpAnimationName);
        }

        public void JumpRight()
        {
            nextPosition += config.RightJumpOffset;
            jumpSpeed = config.SideJumpSpeed;
            _animationController.ChangeState(_sideJumpAnimationName);
        }

        protected void UpdatePosition()
        {
            transform.position =
                Vector3.MoveTowards(transform.position, nextPosition, jumpSpeed * Time.deltaTime);
        }
    }
}