using UnityEngine;

namespace Elements.Behaviours
{
    public class FollowOnTarget : MonoBehaviour
    {

        [SerializeField, Tooltip("Game object to follow.")]
        public GameObject target;

        private float offsetZ;

        private float offsetY;

        void Start()
        {
            offsetY = transform.position.y;
            offsetZ = transform.position.z;
        }

        void Update()
        {
            Vector3 destination = new Vector3
            {
                z = target.transform.position.z + offsetZ,
                x = target.transform.position.x,
                y = target.transform.position.y + offsetY
            };
            transform.position = destination;
        }

    }
}
