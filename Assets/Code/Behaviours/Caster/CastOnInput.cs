﻿using Elements.Data;
using Elements.UI;
using UnityEngine;

namespace Elements.Behaviours
{
    [RequireComponent(typeof(SpellCaster))]
    public class CastOnInput : MonoBehaviour
    {

        public Ability ability;

        private SpellCaster spellCaster;

        public GameObject spellStickContainer;

        private Joystick joystick;

        private void Start()
        {
            joystick = spellStickContainer.GetComponent<Joystick>();
            spellCaster = GetComponent<SpellCaster>();
        }

        void Update()
        {
            if (Input.GetKeyDown("space"))
            {
                CastAbility();
            }

            Vector3 velocity = new Vector3
            {
                x = joystick.JoystickAxis.x,
                y = 0,
                z = joystick.JoystickAxis.y
            };

            spellCaster.velocity = velocity;
            if (velocity.magnitude > 0) 
            {
                CastAbility();
            }

        }

        public void CastAbility()
        {
            spellCaster.CastAbility(ability);
        }

    }

}