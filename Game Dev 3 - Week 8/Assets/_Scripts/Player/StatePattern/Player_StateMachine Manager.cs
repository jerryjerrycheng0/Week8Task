using UnityEngine;
using Unity.VisualScripting;
using Unity.PlasticSCM.Editor.WebApi;
using GameDevWithMarco.Player;

namespace GameDevWithMarco.StatePattern
{
    public class Player_StateMachineManager : MonoBehaviour
    {
        /// <summary>
        /// This script will manage the transitions from state to state
        /// of the state machine.
        /// </summary>


        [SerializeField] Player_StateMachine_BaseState currentState;     //This variable will keep track of what state is currently active


        //These variables will store references to the script that manage each state 
        public Player_StateMachine_IdleState idleState = new Player_StateMachine_IdleState();

        //Variables to manage animations
        public Player_Movement playerMovement;


        // Start is called before the first frame update
        void Start()
        {
            playerMovement = GetComponent<Player_Movement>();              

            currentState = idleState;
            currentState?.EnterState(this);
        }

        public void Update()
        {
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
            currentState?.OnCollisionExit(this, collision);
        }

        public void SwitchState(Zombie_StateMachine_BaseState stateWeWantToUse)
        {
            currentState = stateWeWantToUse;
            currentState?.EnterState(this);
        }
    }
}
