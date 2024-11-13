using UnityEngine;
using GameDevWithMarco.Enemy;

namespace GameDevWithMarco.StatePattern
{
    public class Zombie_StateMachine_Manager : MonoBehaviour
    {
        /// <summary>
        /// This script will manage the transitions from state to state
        /// of the state machine.
        /// </summary>


        [SerializeField] Zombie_StateMachine_BaseState currentState;     //This variable will keep track of what state is currently active


        //These variables will store references to the script that manage each state 
        public Zombie_StateMachine_IdleState idleState = new Zombie_StateMachine_IdleState();
        public Zombie_StateMachine_Moving movingState = new Zombie_StateMachine_Moving();


        //Variables to manage animations
        public Zombie_Animations animScript;

        //Variable to check the zombie type
        public Zombie_Parent zombieParent;

        //Zombie ai/navigation script
        public Zombie_Ai zombieAiScript;

        // Start is called before the first frame update
        void Start()
        {
            animScript = GetComponent<Zombie_Animations>();         //Finds the Animator        
            zombieAiScript = GetComponent<Zombie_Ai>();             //Will find the ai script        
            zombieParent = GetComponent<Zombie_Parent>();           //Will find the parent script
        }
    }
}
