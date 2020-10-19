using Gameplay;
using Targets;
using UnityEngine;

namespace Weapons
{
    public class Revolver : Weapon
    {
        public Revolver(WeaponData data) : base(data)
        {
            
        }

        public override void Fire(Vector2 startPosition, Vector2 direction)
        {
            if (CurrentAmmo <= 0) return;
            CurrentAmmo--;
            Hud.OnAmmoCountUpdated(GetAmmo());
            var hit = CheckForHit(startPosition, direction);
            if (!hit || (!hit.transform.CompareTag("Enemy") && !hit.transform.CompareTag("Box"))) return;
            var target = hit.transform.gameObject;
            target.GetComponent<Target>().TakeDamage(Damage);
        }
    }
}
