using UnityEngine;

namespace GameDevWithMarco.StatePattern
{
    public class Zombie_StateMachine_AttackState : Zombie_StateMachine_BaseState
    {
        public override void EnterState(Zombie_StateMachine_Manager stateMachineManager)
        {
            stateMachineManager.animScript.PlayAttackAnimation();     //Plays the idle animation
        }

        public override void UpdateState(Zombie_StateMachine_Manager stateMachineManager)
        {

        }

        public override void OnCollisionEnter(Zombie_StateMachine_Manager stateMachineManager, Collision collision)
        {

        }

        public override void OnTriggerEnter(Zombie_StateMachine_Manager stateMachineManager, Collider collider)
        {

        }

        public override void OnCollisionExit(Zombie_StateMachine_Manager stateMachineManager, Collision collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                stateMachineManager.SwitchState(stateMachineManager.movingState);
            }
        }
    }
}
