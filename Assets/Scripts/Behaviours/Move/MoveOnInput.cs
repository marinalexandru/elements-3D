using Elements.Data;
using Elements.UI;
using UnityEngine;
using UnityEngine.AI;
namespace Elements.Behaviours
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class MoveOnInput : MonoBehaviour
    {

        [SerializeField, Tooltip("Movement speed.")]
        public FloatVariable speed;

        private Joystick joystick;

        private NavMeshAgent agent;

        void Start()
        {
            joystick = FindObjectOfType<Joystick>();
            agent = GetComponent<NavMeshAgent>();
            agent.angularSpeed = 360*2;
        }

        void Update()
        {
            Vector3 velocity = new Vector3
            {
                x = joystick.JoystickAxis.x,
                y = 0,
                z = joystick.JoystickAxis.y
            };
            Vector3 velocityNormalised = velocity.normalized;
            agent.velocity = speed.value * velocityNormalised;
        }

       
    }
}
