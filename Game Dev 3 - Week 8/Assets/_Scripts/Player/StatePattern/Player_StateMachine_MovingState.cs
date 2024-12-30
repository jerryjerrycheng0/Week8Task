using UnityEngine;

namespace GameDevWithMarco.StatePattern
{
    public class Player_StateMachine_MovingState : Player_StateMachine_BaseState
    {
        public override void EnterState(Player_StateMachine_Manager manager)
        {
            // Handle starting actions while moving
        }

        public override void UpdateState(Player_StateMachine_Manager manager)
        {
            manager.playerMovement.AccellerationDecelleration();

            if (manager.playerMovement.grounded)
            {
                manager.playerMovement.Turning();
            }

            if (Input.GetAxis("Vertical") == 0)
            {
                manager.SwitchState(new Player_StateMachine_IdleState());
            }
        }

        public override void OnCollisionEnter(Player_StateMachine_Manager manager, Collision collision)
        {
            // Handle collisions while moving
        }

        public override void OnTriggerEnter(Player_StateMachine_Manager manager, Collider other)
        {
            // Handle triggers while moving
        }

        public override void OnCollisionExit(Player_StateMachine_Manager manager, Collision collision)
        {
            // Handle collision exit while moving
        }

        public override void ExitState(Player_StateMachine_Manager manager)
        {
            // Handles actions on exit
        }
    }
}
