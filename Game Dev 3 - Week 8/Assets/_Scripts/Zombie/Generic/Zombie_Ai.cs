using UnityEngine;
using UnityEngine.AI;

namespace GameDevWithMarco.Enemy
{
    public class Zombie_Ai : MonoBehaviour
    {
        NavMeshAgent agent;

        [SerializeField] GameObject target;

        public bool isChasing = false;

        Zombie_Parent parentScript;

        // Start is called before the first frame update
        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            target = GameObject.FindGameObjectWithTag("Player");


            //To deal with specifics of the zombie type
            parentScript = GetComponent<Zombie_Parent>();
            //Will set the agent's speed to be the same as the zombie speed
            agent.speed = parentScript.zombieSpeed;
        }

        // Update is called once per frame
        void Update()
        {
            if (isChasing)
            {
                //Will go toward the target
                agent.destination = target.transform.position;
                //Will make sure that the zombie can move
                agent.isStopped = false;
            }
            else
            {
                //Will stop the zombie
                agent.isStopped = true;
            }
        }
    }
}
