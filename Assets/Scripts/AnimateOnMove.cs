using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Elements 
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(Animator))]
    public class AnimateOnMove : MonoBehaviour
    {
        Animator anim;
        NavMeshAgent agent;
        Vector2 velocity = Vector2.zero;

        void Start()
        {
            anim = GetComponent<Animator>();
            agent = GetComponent<NavMeshAgent>();
        }

        void Update()
        {

            float magnitude = agent.velocity.magnitude/5; //remove hardcoded 3 (normalisation)
            bool walk = magnitude > 0;
            anim.SetBool("walk", walk);
            anim.SetBool("free", !walk);
            if (walk)
            {
                anim.speed = 1 * magnitude;
            }
            else
            {
                anim.speed = 0.75f;
            }

        }

    }
}
