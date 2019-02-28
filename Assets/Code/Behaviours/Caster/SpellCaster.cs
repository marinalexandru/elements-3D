using System.Collections;
using System.Collections.Generic;
using Elements.Data;
using UnityEngine;
using UnityEngine.Events;

namespace Elements.Behaviours
{
    public class SpellCaster : MonoBehaviour
    {

        public GameObject from;

        public GameObject target;

        [HideInInspector]
        public Vector3 velocity;

        [HideInInspector]
        public bool isCasting;

        [HideInInspector]
        public UnityEvent OnStartCast;

        [HideInInspector]
        public UnityEvent OnReleaseCast;

        [HideInInspector]
        public UnityEvent OnEndCast;

        private Dictionary<Ability, float> cooldownTable;

        private float castFinishTime;

        void Start()
        {
            ResetCooldowns();
        }

        void Update()
        {
            isCasting = castFinishTime >= Time.time;
        }

        public void ResetCooldowns()
        {
            cooldownTable = new Dictionary<Ability, float>();
            isCasting = false;
            castFinishTime = 0;
        }

        public void CastAbility(Ability ability)
        {
            if (isCasting)
                return;
            
            if (IsOnCooldown(ability))
                return;
            if (ability is HommingSpell)
            {
                (ability as HommingSpell).AimAt(gameObject, target.transform);
            }
            else if (ability is AimedSpell)
            {
                (ability as AimedSpell).AimAt(gameObject, velocity);
            }

            castFinishTime = ability.castTime + Time.time;

            cooldownTable[ability] = ability.coolDown + Time.time;
    
            OnStartCast.Invoke();
            StartCoroutine(ReleaseCast(ability));
            StartCoroutine(EndCast(ability));
        }

        private bool IsOnCooldown(Ability ability)
        {
            cooldownTable.TryGetValue(ability, out float time);
            return time >= Time.time;
        }

        IEnumerator ReleaseCast(Ability ability)
        {

            yield return new WaitForSeconds(ability.releaseAt);

            if (ability is HommingSpell)
            {
                (ability as HommingSpell).Cast(gameObject, from.transform, target.transform);
            
            } else if (ability is AimedSpell)
            {
                (ability as AimedSpell).Cast(gameObject, from.transform, velocity);
            }

            OnReleaseCast.Invoke();
        }

        IEnumerator EndCast(Ability ability)
        {
            yield return new WaitForSeconds(ability.castTime);
            OnEndCast.Invoke();
        }
    }

}
