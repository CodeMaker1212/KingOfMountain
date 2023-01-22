using UnityEngine;
using Zenject;

namespace KingOfMountain
{
    public class EnemyJumpingBehavior : JumpingBehavior
    {
        private float _rotationSpeed = 5.0f;

        private void Start()
        {
            nextPosition = transform.position;

            DetermineNextJump();
        }

        private void Update()
        {
            MovePosition();

            LookAtJumpDirection(); 
        }

        private void LookAtJumpDirection()
        {
            var lookPoint = nextPosition - Vector3.forward;
            var lookDirection = lookPoint - transform.position;

            transform.rotation =
                Quaternion.Slerp(transform.rotation,
                                 Quaternion.LookRotation(lookDirection),
                                _rotationSpeed * Time.deltaTime);

            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        }

        // Вызывается событием анимации.
        private void DetermineNextJump()
        {
            int forwardDirection = 0;
            int leftDirection = -1;
            int rightDirection = 1;
            int selectedDirection;
 
            if (transform.position.x == 0)
            {
                selectedDirection = Random.Range(leftDirection, rightDirection + 1);

                if (selectedDirection == leftDirection)             
                    JumpLeft();
                
                else if (selectedDirection == rightDirection)
                    JumpRight();  
                
                else 
                    JumpStraight();
            }

            if (transform.position.x < 0)
            {
                selectedDirection = Random.Range(leftDirection, forwardDirection + 1);

                if (selectedDirection == leftDirection)
                    JumpLeft();

                else
                    JumpStraight();
            }

            if (transform.position.x > 0)
            {
                 selectedDirection = Random.Range(forwardDirection, rightDirection + 1);

                if (selectedDirection == rightDirection)
                    JumpRight();

                else
                    JumpStraight();
            }  
        }    
    }
}