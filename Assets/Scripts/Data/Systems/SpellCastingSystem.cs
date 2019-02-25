using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Elements.Data
{
    [CreateAssetMenu]
    public class SpellCastingSystem : ScriptableObject
    {

        public SpellCastEvent OnSpellCast { get; set; }

        private Dictionary<int, bool> isCasting;


        private void OnEnable()
        {
            if (isCasting == null)
            {
                isCasting = new Dictionary<int, bool>();
            }
            if (OnSpellCast == null)
            {
                OnSpellCast = new SpellCastEvent();
            }
        }

        public bool IsCasting(GameObject gameObject)
        {
            isCasting.TryGetValue(gameObject.GetInstanceID(), out bool casting);
            return casting;
        }

        public void CastSpell(Spell spell, MonoBehaviour caster, Transform from, Transform to=null) 
        {
            var instanceId = caster.gameObject.GetInstanceID();

            if (IsCasting(caster.gameObject))
            { 
                return; 
            }

            OnSpellCast.Invoke(spell, instanceId);
            isCasting[instanceId] = true;

            caster.StartCoroutine(FireSpell(spell, caster, from, to));
            caster.StartCoroutine(FinishSpell(spell, instanceId));
        }

        private IEnumerator FireSpell(Spell spell, MonoBehaviour caster, Transform from, Transform to)
        { 
            yield return new WaitForSeconds(spell.releaseProjectileAt);
            var proj = Instantiate(spell.projectile, from.position, from.rotation);
            var projRigidBody = proj.GetComponent<Rigidbody>();
            projRigidBody.velocity = caster.transform.TransformDirection(Vector3.forward * spell.projectileSpeed);
        }

        private IEnumerator FinishSpell(Spell spell, int instanceId)
        {
            yield return new WaitForSeconds(spell.castTime);
            isCasting[instanceId] = false;
        }

    }
}
