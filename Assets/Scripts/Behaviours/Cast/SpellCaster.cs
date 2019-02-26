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

        private Dictionary<Spell, float> cooldownTable;

        private Spell currentSpell;

        private float castFinishTime;

        private float nextReleaseAtTime = float.MaxValue;

        void Start()
        {
            ResetCooldowns();
        }

        void Update()
        {
            bool releaseTimePassed = Time.time > nextReleaseAtTime;
            isCasting = castFinishTime >= Time.time;
            if (releaseTimePassed)
            {
                ReleaseSpell();
            }
        }

        public void ResetCooldowns()
        {
            cooldownTable = new Dictionary<Spell, float>();
            isCasting = false;
            castFinishTime = 0;
            nextReleaseAtTime = float.MaxValue;
        }

        public void CastSpell(Spell spell)
        {
            if (isCasting)
            {
                return;
            }
            if (IsOnCooldown(spell))
            {
                return;
            }

            castFinishTime = spell.castTime + Time.time;
            nextReleaseAtTime = spell.releaseAt + Time.time;

            cooldownTable[spell] = spell.coolDown + Time.time;
    
            OnStartCast.Invoke();
            isCasting = true;
            currentSpell = spell;

        }

        private bool IsOnCooldown(Spell spell)
        {
            cooldownTable.TryGetValue(spell, out float time);
            return time >= Time.time;
        }

        private void ReleaseSpell()
        {
            nextReleaseAtTime = float.MaxValue;
            currentSpell.Cast(gameObject, from.transform, target.transform);
            currentSpell = null;
        }
    }

}
