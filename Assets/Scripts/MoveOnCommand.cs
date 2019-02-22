using System.Collections;
using System.Collections.Generic;
using Elements.UI;
using UnityEngine;
using UnityEngine.AI;
namespace Elements
{
    public class MoveOnCommand : MonoBehaviour
    {
        private UIJoystick joystick;
        private NavMeshAgent agent;
        [SerializeField]
        private float speed;


        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            agent.angularSpeed = 360;
            joystick = FindObjectOfType<UIJoystick>();
        }

        void Update()
        {
            Vector3 normalisedVelocity = new Vector3
            {
                x = joystick.JoystickAxis.x,
                y = 0,
                z = joystick.JoystickAxis.y
            };
            float normalisedMagnitude = normalisedVelocity.magnitude;
            agent.velocity = speed*normalisedVelocity;
        }
    }
}
