using UnityEngine;

namespace Elements.Data
{
    public abstract class Ability : ScriptableObject
    {

        [SerializeField]
        public float castTime;

        [SerializeField]
        public float coolDown;

        [SerializeField]
        public float releaseAt;

        [SerializeField]
        public GameObject projectile;

        [SerializeField]
        public float projectileSpeed;

        [SerializeField]
        public float range;


    }
}
