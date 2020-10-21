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

        public override void Fire(Vector2 startPosition, Vector2 direction, LayerMask layerMask)
        {
            if (CurrentAmmo <= 0 || _shotCount >= 3)
            {
                _shotCount = 0;
                return;
            }
            CurrentAmmo--;
            _shotCount++;
            Fire(startPosition, direction, layerMask);
            Hud.OnAmmoCountUpdated(GetAmmo());
            var hit = CheckForHit(startPosition, direction, layerMask);
            if (!hit || (!hit.transform.CompareTag("Enemy") && !hit.transform.CompareTag("Box"))) return;
            var target = hit.transform.gameObject;
            target.GetComponent<Target>().TakeDamage(Damage);
            SpawnEffect(hit.point);
        }
    }
}
