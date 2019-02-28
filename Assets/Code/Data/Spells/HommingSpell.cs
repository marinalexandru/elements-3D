
using Elements.Behaviours;
using UnityEngine;

namespace Elements.Data
{
    [CreateAssetMenu]
    public class HommingSpell : Ability
    {

        public void Cast(GameObject caster, Transform spawn, Transform target) 
        {
            var proj = Instantiate(projectile, spawn.position, spawn.rotation);
            var hommingScript = proj.GetComponent<HommingProjectile>();
            hommingScript.speed = projectileSpeed;
            hommingScript.target = target;
        }

        public void AimAt(GameObject caster, Transform target)
        {
            caster.transform.LookAt(target);
        }

    }
}
