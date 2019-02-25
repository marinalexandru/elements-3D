using System;
using UnityEngine.Events;

namespace Elements.Data
{
    [Serializable]
    public class SpellCastEvent : UnityEvent<Spell,int>
    {

    }
}
