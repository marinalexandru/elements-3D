
using UnityEngine;

namespace Elements.Data
{

    [CreateAssetMenu]
    public class Spell : ScriptableObject
    {


        [SerializeField]
        public float castTime;

        [SerializeField]
        public float releaseProjectileAt;

        [SerializeField]
        public SpellType spellType;

        [SerializeField]
        public GameObject projectile;

        [SerializeField]
        public float projectileSpeed;



    }
}
