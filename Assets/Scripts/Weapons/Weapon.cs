using UnityEngine;

namespace Weapons
{
    public abstract class Weapon : IWeapon
    {
        protected int CurrentAmmo;
        protected int MaxAmmo;
        protected float Damage;
        protected float Range;
        protected Sprite CharacterSprite;

        protected Weapon(WeaponData data)
        {
            Damage = data.damage;
            Range = data.range;
            CharacterSprite = data.characterSprite;
            MaxAmmo = data.maxAmmo;
            CurrentAmmo = MaxAmmo;
        }
        public virtual void Fire(Vector2 startPosition, Vector2 direction)
        {
            
        }

        protected RaycastHit2D CheckForHit(Vector2 startPosition, Vector2 direction)
        {
            return Physics2D.Raycast(startPosition, direction, Range);
        }

        public void AddAmmo()
        {
            
        }

        public Sprite GetSprite()
        {
            return CharacterSprite;
        }
    }
}
