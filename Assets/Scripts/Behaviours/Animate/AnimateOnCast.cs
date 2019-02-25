

using Elements.Data;
using UnityEngine;

namespace Elements.Behaviours
{
    [RequireComponent(typeof(Animator))]
    public class AnimateOnCast : MonoBehaviour
    {

        public SpellCastingSystem spellCastingSystem;

        private Animator anim;

        void Start()
        {
            anim = GetComponent<Animator>();
            spellCastingSystem.OnSpellCast.AddListener(AnimateSkill);
        }

        public void AnimateSkill(Spell spell, int instanceId)
        {
            if (instanceId != gameObject.GetInstanceID())
            {
                return;
            }
            anim.SetTrigger("skill");
        }

    }
}
