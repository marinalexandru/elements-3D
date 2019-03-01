using Elements.Behaviours;
using UnityEngine;

namespace Elements.Data
{
    [CreateAssetMenu]
    public class AimedSpell : Ability
    {
        public override void Cast(SpellCaster caster)
        {
            var spawn = caster.spawn;
            var proj = Instantiate(projectile, spawn.transform.position, spawn.transform.rotation);
            var hommingScript = proj.GetComponent<AimedProjectile>();
            hommingScript.speed = projectileSpeed;
            hommingScript.velocity = caster.velocity;
        }

        public override void AimAt(SpellCaster caster) 
        {
            caster.transform.LookAt(caster.velocity);
        }
    }
}
