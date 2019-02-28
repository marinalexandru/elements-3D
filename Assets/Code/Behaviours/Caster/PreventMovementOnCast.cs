using UnityEngine;
using UnityEngine.AI;

namespace Elements.Behaviours
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(SpellCaster))]
    public class PreventMovementOnCast : MonoBehaviour
    {

        private SpellCaster spellCaster;
        private NavMeshAgent agent;

        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            spellCaster = GetComponent<SpellCaster>();
        }

        void Update()
        {
            agent.enabled = !spellCaster.isCasting;
        }
    }
}
