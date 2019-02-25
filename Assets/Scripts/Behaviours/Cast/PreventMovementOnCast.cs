using Elements.Data;
using UnityEngine;
using UnityEngine.AI;

namespace Elements.Behaviours
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class PreventMovementOnCast : MonoBehaviour
    {

        public SpellCastingSystem spellCatingSystem;
        private NavMeshAgent agent;


        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
        }

        void Update()
        {
            agent.enabled = !spellCatingSystem.IsCasting(gameObject);
        }
    }
}
