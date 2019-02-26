using Elements.Data;
using UnityEngine;

namespace Elements.Behaviours
{
    [RequireComponent(typeof(SpellCaster))]
    public class CastOnInput : MonoBehaviour
    {

        public Spell spell;

        private SpellCaster spellCaster;

        private void Start()
        {
            spellCaster = GetComponent<SpellCaster>();
        }

        void Update()
        {
            if (Input.GetKeyDown("space"))
            {
                CastSpell();
            }
        }

        public void CastSpell()
        {
            spellCaster.CastSpell(spell);
        }

    }

}