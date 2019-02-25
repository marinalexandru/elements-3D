using Elements.Data;
using UnityEngine;

public class CastOnInput : MonoBehaviour
{

    public SpellCastingSystem spellCastingSystem;

    public GameObject from;

    public Spell spell;

    private void Start()
    {
        //spellCastingSystem.EnableCasting(gameObject);
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            spellCastingSystem.CastSpell(spell, this, from.transform, null);
        }
    }

    public void CastSpell()
    {
        spellCastingSystem.CastSpell(spell, this, from.transform, null);
    }

}
