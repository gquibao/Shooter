using System.Linq;
using Targets;
using UnityEngine;

namespace Weapons
{
    public class MissileLauncher : Weapon
    {
        public MissileLauncher(WeaponData data) : base(data)
        {
        }
        
        public override void Fire(Vector2 startPosition, Vector2 direction)
        {
            if (CurrentAmmo <= 0) return;
            CurrentAmmo--;
            Debug.Log($"Shot Missile");
            var hit = CheckForHit(startPosition, direction);
            if (!hit || (!hit.transform.CompareTag("Enemy") && !hit.transform.CompareTag("Box"))) return;
            var target = hit.transform.gameObject;
            target.GetComponent<Target>().TakeDamage(Damage);
            var secondaryHits = Physics2D.CircleCastAll(target.transform.position, 10f, direction);
            secondaryHits.ToList().ForEach(secondaryHit =>
            {
                secondaryHit.transform.gameObject.TryGetComponent(out Target secondaryTarget);
                if(secondaryTarget != null) secondaryTarget.TakeDamage(Damage/3);
            });
        }
    }
}
