using UnityEngine;

namespace Elements.Behaviours
{
    public class HommingProjectile : MonoBehaviour
    {

        [HideInInspector]
        public Transform target;

        [HideInInspector]
        public float speed;

        private Vector3 start;


        // Use this for initialization
        void Start()
        {
            start = transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
        }
    }

}
