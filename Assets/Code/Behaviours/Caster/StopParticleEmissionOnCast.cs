using UnityEngine;
namespace Elements.Behaviours
{

    [RequireComponent(typeof(SpellCaster))]
    public class StopParticleEmissionOnCast : MonoBehaviour
    {

        public GameObject orb;

        private ParticleSystem _CachedSystem;

        private ParticleSystem System
        {
            get
            {
                if (_CachedSystem == null)
                    _CachedSystem = orb.GetComponent<ParticleSystem>();
                return _CachedSystem;
            }
        }

        private SpellCaster spellCaster;

        void Start()
        {
            spellCaster = GetComponent<SpellCaster>();
            spellCaster.OnStartCast.AddListener(BlockParticleSystem);
            spellCaster.OnEndCast.AddListener(ResumeParticleSystem);
        }

        private void BlockParticleSystem()
        {
            System.Stop(true);
        }

        private void ResumeParticleSystem()
        {
            System.Play(true);
        }

    }
}
