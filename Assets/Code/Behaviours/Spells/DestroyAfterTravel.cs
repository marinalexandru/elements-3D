using Elements.Data;
using UnityEngine;

namespace Elements.Behaviours
{
    public class DestroyAfterTravel : MonoBehaviour
    {

        private Vector3 initialPosition;

        public AimedSpell spell;

        // Use this for initialization
        void Start()
        {
            initialPosition = transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            if (Vector3.Distance(transform.position, initialPosition) > spell.range) 
            {
                Destroy(gameObject);
            }
        }
    }

}
