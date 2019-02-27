
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

        public void Cast(GameObject caster, Transform spawn, Transform target) 
        {
            var proj = Instantiate(projectile, spawn.position, spawn.rotation);
            var hommingScript = proj.GetComponent<HommingSpell>();
            hommingScript.speed = projectileSpeed;
            hommingScript.target = target;
        }

        public void AimAt(GameObject caster, Transform target)
        {
            caster.transform.LookAt(target);
        }

    }
}
