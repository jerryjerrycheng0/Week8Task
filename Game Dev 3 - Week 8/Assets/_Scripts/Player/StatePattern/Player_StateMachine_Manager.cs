using UnityEngine;
using GameDevWithMarco.Player;

namespace GameDevWithMarco.StatePattern
{
    public class Player_StateMachine_Manager : MonoBehaviour
    {
        public Player_StateMachine_BaseState currentState;

        public Player_StateMachine_IdleState idleState = new Player_StateMachine_IdleState();
        public Player_StateMachine_MovingState movingState = new Player_StateMachine_MovingState();
        public Player_StateMachine_DashState dashState = new Player_StateMachine_DashState();
        public Player_StateMachine_AirborneState airboneState = new Player_StateMachine_AirborneState();

        public Player_Movement playerMovement;

        void Start()
        {
            playerMovement = GetComponent<Player_Movement>();

            currentState = idleState;
            currentState.EnterState(this);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && currentState is Player_StateMachine_MovingState)
            {
                // Switch to Dash State if moving and Left Shift is pressed
                SwitchState(new Player_StateMachine_DashState());
            }

            currentState.UpdateState(this);
        }

        private void OnCollisionEnter(Collision collision)
        {
            currentState.OnCollisionEnter(this, collision);
        }

        private void OnTriggerEnter(Collider other)
        {
            currentState.OnTriggerEnter(this, other);
        }

        private void OnCollisionExit(Collision collision)
        {
            currentState.OnCollisionExit(this, collision);
        }

        public void SwitchState(Player_StateMachine_BaseState newState)
        {
            currentState.ExitState(this);
            currentState = newState;
            currentState.EnterState(this);
        }
    }
}
