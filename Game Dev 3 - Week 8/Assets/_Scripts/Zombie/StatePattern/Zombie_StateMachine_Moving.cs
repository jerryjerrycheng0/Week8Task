using UnityEngine;
using GameDevWithMarco.Enemy;

namespace GameDevWithMarco.StatePattern
{
    public class Zombie_StateMachine_Moving : Zombie_StateMachine_BaseState
    {
        public override void EnterState(Zombie_StateMachine_Manager stateMachineManager)
        {
            //Plays a different animation based on the zombie type
            switch (stateMachineManager.zombieParent.whatTypeIsThisZombie)
            {
                case Zombie_Parent.ZombieType.Walker:
                    stateMachineManager.animScript.PlayWalkAnimation();
                    break;
                case Zombie_Parent.ZombieType.Runner:
                    stateMachineManager.animScript.PlayRunAnimation();
                    break;
                default:
                    break;
            }
        }

        public override void UpdateState(Zombie_StateMachine_Manager stateMachineManager)
        {
            if (stateMachineManager.zombieAiScript.isChasing == false)
            {
                stateMachineManager.SwitchState(stateMachineManager.idleState);
            }
        }

        public override void OnCollisionEnter(Zombie_StateMachine_Manager stateMachineManager, Collision collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                stateMachineManager.SwitchState(stateMachineManager.attackState);
            }
        }

        public override void OnTriggerEnter(Zombie_StateMachine_Manager stateMachineManager, Collider collider)
        {

        }

        public override void OnCollisionExit(Zombie_StateMachine_Manager stateMachineManager, Collision collision)
        {
            
        }
    }
}
