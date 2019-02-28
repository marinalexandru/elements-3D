using UnityEngine;
using UnityEngine.AI;

namespace Elements.Behaviours
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Patrol : MonoBehaviour
    {

        public Transform[] points;

        private int destPoint = 0;

        private NavMeshAgent agent;

        void Start()
        {
            agent = GetComponent<NavMeshAgent>();

            agent.autoBraking = false;

            GotoNextPoint();
        }


        void GotoNextPoint()
        {
            if (points.Length == 0)
                return;
                
            agent.destination = points[destPoint].position;

            destPoint = (destPoint + 1) % points.Length;
        }


        void Update()
        {
            if (agent.isActiveAndEnabled && !agent.pathPending && agent.remainingDistance < 2.5f)
                GotoNextPoint();
        }
    }
}

