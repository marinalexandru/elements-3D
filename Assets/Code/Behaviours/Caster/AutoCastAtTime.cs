using UnityEngine;
using System.Collections;
using Elements.Data;

namespace Elements.Behaviours
{
    [RequireComponent(typeof(SpellCaster))]
    public class AutoCastAtTime : MonoBehaviour
    {

        public Ability ability;

        public float castTime;

        private SpellCaster spellCaster;

        private void Start()
        {
            spellCaster = GetComponent<SpellCaster>();
            StartCoroutine(CastAtTime(castTime));
        }

        IEnumerator CastAtTime(float time)
        {
            while (true)
            {
                yield return new WaitForSeconds(time);
                spellCaster.CastAbility(ability);
            }
        }

    }

}
