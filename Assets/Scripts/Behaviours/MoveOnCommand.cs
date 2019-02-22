using Elements.Data;
using Elements.UI;
using UnityEngine;
using UnityEngine.AI;
namespace Elements.Behaviours
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class MoveOnCommand : MonoBehaviour
    {

        [SerializeField, Tooltip("Movement speed.")]
        public FloatVariable speed;

        private Joystick joystick;

        private NavMeshAgent agent;

        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            agent.angularSpeed = 360;
            joystick = FindObjectOfType<Joystick>();
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
            agent.velocity = speed.value*normalisedVelocity;
        }
    }
}
