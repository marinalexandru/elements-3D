

using UnityEngine;

namespace Elements.Behaviours
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(SpellCaster))]
    public class AnimateOnCast : MonoBehaviour
    {

        private Animator anim;

        private SpellCaster spellCaster;

        void Start()
        {
            anim = GetComponent<Animator>();
            spellCaster = GetComponent<SpellCaster>();
            spellCaster.OnStartCast.AddListener(AnimateSkill);
        }

        public void AnimateSkill()
        {
            anim.SetTrigger("skill");
        }

    }
}
