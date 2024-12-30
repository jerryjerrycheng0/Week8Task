using UnityEngine;

namespace GameDevWithMarco.StatePattern
{
    public abstract class Player_StateMachine_BaseState
    {
        public abstract void EnterState(Player_StateMachine_Manager manager);
        public abstract void UpdateState(Player_StateMachine_Manager manager);
        public abstract void OnCollisionEnter(Player_StateMachine_Manager manager, Collision collision);
        public abstract void OnTriggerEnter(Player_StateMachine_Manager manager, Collider other);
        public abstract void OnCollisionExit(Player_StateMachine_Manager manager, Collision collision);
        public abstract void ExitState(Player_StateMachine_Manager manager);
    }

}
