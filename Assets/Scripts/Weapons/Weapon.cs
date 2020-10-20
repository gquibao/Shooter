using System;
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
        public virtual void Fire(Vector2 startPosition, Vector2 direction, LayerMask layerMask)
        {
            
        }

        protected RaycastHit2D CheckForHit(Vector2 startPosition, Vector2 direction, LayerMask layerMask)
        {
            return Physics2D.Raycast(startPosition, direction, Range, layerMask);
        }

        public void AddAmmo()
        {
            CurrentAmmo += MaxAmmo / 2;
        }

        public Sprite GetSprite()
        {
            return CharacterSprite;
        }

        public Tuple<int, int> GetAmmo()
        {
            return new Tuple<int, int>(CurrentAmmo, MaxAmmo);
        }
    }
}
