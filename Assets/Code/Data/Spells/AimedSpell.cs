using Elements.Behaviours;
using UnityEngine;

namespace Elements.Data
{
    [CreateAssetMenu]
    public class AimedSpell : Ability
    {
        public void Cast(GameObject caster, Transform spawn, Vector3 velocity)
        {
            var proj = Instantiate(projectile, spawn.position, spawn.rotation);
            var hommingScript = proj.GetComponent<AimedProjectile>();
            hommingScript.speed = projectileSpeed;
            hommingScript.velocity = velocity;
        }

        public void AimAt(GameObject caster, Vector3 velocity) 
        {
            caster.transform.LookAt(velocity);
        }
    }
}
