using UnityEngine;

namespace GameDevWithMarco.StatePattern
{
    public class Player_StateMachine_DashState : Player_StateMachine_BaseState
    {
        private float dashSpeedMultiplier = 2f; // Multiplier for dash speed
        private float originalSpeed;

        public override void EnterState(Player_StateMachine_Manager manager)
        {
            // Increase speed when entering Dash State
            originalSpeed = manager.playerMovement.forwardAccell;
            manager.playerMovement.forwardAccell *= dashSpeedMultiplier;
        }

        public override void UpdateState(Player_StateMachine_Manager manager)
        {
            manager.playerMovement.AccellerationDecelleration();

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                // Transition back to Idle or Moving State when Dash key is released
                if (Input.GetAxis("Vertical") == 0)
                {
                    manager.SwitchState(new Player_StateMachine_IdleState());
                }
                else
                {
                    manager.SwitchState(new Player_StateMachine_MovingState());
                }
            }
        }

        public override void OnCollisionEnter(Player_StateMachine_Manager manager, Collision collision)
        {
            // Handle collisions while dashing
        }

        public override void OnTriggerEnter(Player_StateMachine_Manager manager, Collider other)
        {
            // Handle triggers while dashing
        }

        public override void OnCollisionExit(Player_StateMachine_Manager manager, Collision collision)
        {
            // Handle collision exit while dashing
        }

        public override void ExitState(Player_StateMachine_Manager manager)
        {
            // Restore the original speed when exiting Dash State
            manager.playerMovement.forwardAccell = originalSpeed;
        }
    }
}

