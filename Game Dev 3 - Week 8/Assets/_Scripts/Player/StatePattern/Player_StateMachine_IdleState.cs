using UnityEngine;

namespace GameDevWithMarco.StatePattern
{
    public class Player_StateMachine_IdleState : Player_StateMachine_BaseState
    {
        public override void EnterState(Player_StateMachine_Manager manager)
        {
            manager.playerMovement.speedInput = 0; // Stop movement
        }

        public override void UpdateState(Player_StateMachine_Manager manager)
        {
            if (Input.GetAxis("Vertical") != 0)
            {
                manager.SwitchState(new Player_StateMachine_MovingState());
            }
        }

        public override void OnCollisionEnter(Player_StateMachine_Manager manager, Collision collision)
        {
            // Handle collision while idle
        }

        public override void OnTriggerEnter(Player_StateMachine_Manager manager, Collider other)
        {
            // Handle triggers while idle
        }

        public override void OnCollisionExit(Player_StateMachine_Manager manager, Collision collision)
        {
            // Handle collision exit while idle
        }
        public override void ExitState(Player_StateMachine_Manager manager)
        {
            // Handles actions on exit
        }
    }
}
