using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Animations;

namespace Weapons
{
    public class Melee : Weapon
    {
        public Melee(WeaponData data) : base(data)
        {
            
        }

        public void Fire(Vector2 startPosition, Vector2 direction)
        {
            RaycastHit2D hit;
            hit = Physics2D.Raycast(startPosition, direction, Range);
            if (hit.transform != null)
                Debug.Log($"{hit.transform.name} took {Damage} damage");
        }
    }
}