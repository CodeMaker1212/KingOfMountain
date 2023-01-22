using UnityEngine;

namespace KingOfMountain
{
    [RequireComponent(typeof(Animator))]

    public abstract class JumpingBehavior : MonoBehaviour
    {
        [SerializeField] protected JumpingConfig config;
        protected AnimationController _animationController;

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
            _animationController.ChangeState("StraightJump");
        }

        public void JumpLeft()
        {
            nextPosition += config.LeftJumpOffset;
            jumpSpeed = config.SideJumpSpeed;
            _animationController.ChangeState("SideJump");
        }

        public void JumpRight()
        {
            nextPosition += config.RightJumpOffset;
            jumpSpeed = config.SideJumpSpeed;
            _animationController.ChangeState("SideJump");
        }

        protected void MovePosition()
        {
            transform.position =
                Vector3.MoveTowards(transform.position, nextPosition, jumpSpeed * Time.deltaTime);
        }
    }
}