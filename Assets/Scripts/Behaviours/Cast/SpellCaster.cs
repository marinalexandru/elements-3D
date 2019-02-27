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
        public bool isCasting;

        [HideInInspector]
        public UnityEvent OnStartCast;

        [HideInInspector]
        public UnityEvent OnReleaseCast;

        [HideInInspector]
        public UnityEvent OnEndCast;

        private Dictionary<Spell, float> cooldownTable;

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
            cooldownTable = new Dictionary<Spell, float>();
            isCasting = false;
            castFinishTime = 0;
        }

        public void CastSpell(Spell spell)
        {
            if (isCasting)
                return;
            
            if (IsOnCooldown(spell))
                return;

            spell.AimAt(gameObject,target.transform);

            castFinishTime = spell.castTime + Time.time;

            cooldownTable[spell] = spell.coolDown + Time.time;
    
            OnStartCast.Invoke();
            StartCoroutine(ReleaseCast(spell));
            StartCoroutine(EndCast(spell));
        }

        private bool IsOnCooldown(Spell spell)
        {
            cooldownTable.TryGetValue(spell, out float time);
            return time >= Time.time;
        }

        IEnumerator ReleaseCast(Spell spell)
        {
            yield return new WaitForSeconds(spell.releaseAt);
            spell.Cast(gameObject, from.transform, target.transform);
            OnReleaseCast.Invoke();
        }

        IEnumerator EndCast(Spell spell)
        {
            yield return new WaitForSeconds(spell.castTime);
            OnEndCast.Invoke();
        }
    }

}
