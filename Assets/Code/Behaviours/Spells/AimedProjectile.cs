using UnityEngine;

namespace Elements.Behaviours
{
    [RequireComponent(typeof(Rigidbody))]
    public class AimedProjectile : MonoBehaviour
    {

        [HideInInspector]
        public Vector3 velocity;

        [HideInInspector]
        public float speed;

        private void Update()
        {
            Vector3 velocityNormalised = velocity.normalized;
            GetComponent<Rigidbody>().velocity = velocityNormalised*speed;
        }

    }
}

