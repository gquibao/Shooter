using Gameplay;
using Targets;
using UnityEngine;

namespace Weapons
{
    public class Smg : Weapon
    {
        private int _shotCount;
        public Smg(WeaponData data) : base(data)
        {
        }

        public override void Fire(Vector2 startPosition, Vector2 direction)
        {
            if (CurrentAmmo <= 0 || _shotCount >= 3)
            {
                _shotCount = 0;
                return;
            }
            CurrentAmmo--;
            _shotCount++;
            Fire(startPosition, direction);
            Hud.OnAmmoCountUpdated(GetAmmo());
            var hit = CheckForHit(startPosition, direction);
            if (!hit || (!hit.transform.CompareTag("Enemy") && !hit.transform.CompareTag("Box"))) return;
            var target = hit.transform.gameObject;
            target.GetComponent<Target>().TakeDamage(Damage);
        }
    }
}
