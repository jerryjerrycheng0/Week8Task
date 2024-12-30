using UnityEngine;

namespace GameDevWithMarco.StatePattern
{
    public class Player_StateMachine_AirborneState : Player_StateMachine_BaseState
    {
        public override void EnterState(Player_StateMachine_Manager manager)
        {
            Debug.Log("Entered Airborne State");
        }

        public override void UpdateState(Player_StateMachine_Manager manager)
        {
            // Apply gravity force and other airborne behaviors
            manager.playerMovement.PushCarDownToGround();

            // Check if the player lands back on the ground
            if (manager.playerMovement.grounded)
            {
                manager.SwitchState(new Player_StateMachine_IdleState());
            }
        }

        public override void OnCollisionEnter(Player_StateMachine_Manager manager, Collision collision)
        {
            // Check if the collision indicates the player has landed
            if (manager.playerMovement.grounded)
            {
                manager.SwitchState(new Player_StateMachine_IdleState());
            }
        }

        public override void OnTriggerEnter(Player_StateMachine_Manager manager, Collider other)
        {
            // Handle airborne-specific triggers (e.g., flying through a checkpoint)
        }

        public override void OnCollisionExit(Player_StateMachine_Manager manager, Collision collision)
        {
            // Handle collision exit while airborne (e.g., leaving a surface mid-jump)
        }

        public override void ExitState(Player_StateMachine_Manager manager)
        {
            // Handles actions on exit
        }
    }
}
