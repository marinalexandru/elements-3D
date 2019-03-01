
using Elements.Behaviours;
using UnityEngine;

namespace Elements.Data
{
    [CreateAssetMenu]
    public class HommingSpell : Ability
    {

        public override void Cast(SpellCaster caster) 
        {
            var spawn = caster.spawn;
            var proj = Instantiate(projectile, spawn.transform.position, spawn.transform.rotation);
            var hommingScript = proj.GetComponent<HommingProjectile>();
            hommingScript.speed = projectileSpeed;
            hommingScript.target = caster.target.transform;
        }

        public override void AimAt(SpellCaster caster)
        {
            caster.transform.LookAt(caster.target.transform);
        }

    }
}
