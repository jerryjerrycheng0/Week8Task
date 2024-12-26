
using UnityEngine;

namespace GameDevWithMarco.StatePattern
{
    public class Player_StateMachine_BaseState : MonoBehaviour

        {

            /// <summary>
            /// This script defines the base of what the states will be.
            /// It has four methods that will be used to achieve different results.
            /// </summary>


            public abstract void EnterState(Player_StateMachine_BaseState stateMachineManager);

            public abstract void UpdateState(Player_StateMachine_BaseState stateMachineManager);

            public abstract void OnCollisionEnter(Player_StateMachine_BaseState stateMachineManager, Collision collision);

            public abstract void OnTriggerEnter(Player_StateMachine_BaseState stateMachineManager, Collider collider);

            public abstract void OnCollisionExit(Player_StateMachine_BaseState stateMachineManager, Collision collision);

        }
    }

