using Elements.Data;
using UnityEngine;
using UnityEngine.AI;

namespace Elements.Behaviours 
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(Animator))]
    public class AnimateOnMove : MonoBehaviour
    {

        public FloatVariable speed;

        private Animator anim;

        private NavMeshAgent agent;

        private Vector2 velocity = Vector2.zero;

        void Start()
        {
            anim = GetComponent<Animator>();
            agent = GetComponent<NavMeshAgent>();
        }

        void Update()
        {
            float magnitude = agent.velocity.magnitude / speed.value; 
            bool walk = magnitude > 0;

            anim.SetBool("walk", walk);
            anim.SetBool("free", !walk);

        }

    }
}
