﻿using System;
using Targets;
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

        public override void Fire(Vector2 startPosition, Vector2 direction)
        {
            var hit = CheckForHit(startPosition, direction);
            if (!hit || (!hit.transform.CompareTag("Enemy") && !hit.transform.CompareTag("Box"))) return;
            Debug.Log("HittingEnemy");
            var target = hit.transform.gameObject;
            target.GetComponent<Target>().TakeDamage(Damage);
        }
    }
}