
using Elements.Behaviours;
using UnityEngine;

namespace Elements.Data
{

    [CreateAssetMenu]
    public class Spell : ScriptableObject
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

        public void Cast(GameObject caster, Transform from, Transform to) 
        {
            var proj = Instantiate(projectile, from.position, from.rotation);
            var hommingScript = proj.GetComponent<HommingSpell>();
            hommingScript.speed = projectileSpeed;
            hommingScript.target = to;
        }

    }
}
