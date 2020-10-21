using System;
using Gameplay;
using UnityEngine;

namespace Weapons
{
    public abstract class Weapon : IWeapon
    {
        protected int CurrentAmmo;
        protected readonly float Damage;
        private readonly int _maxAmmo;
        private readonly float _range;
        private readonly Sprite _characterSprite;
        private GameObject _effect;

        protected Weapon(WeaponData data)
        {
            Damage = data.damage;
            _range = data.range;
            _characterSprite = data.characterSprite;
            _maxAmmo = data.maxAmmo;
            CurrentAmmo = _maxAmmo;
            _effect = data.effect;
        }
        public virtual void Fire(Vector2 startPosition, Vector2 direction, LayerMask layerMask)
        {
            
        }

        protected RaycastHit2D CheckForHit(Vector2 startPosition, Vector2 direction, LayerMask layerMask)
        {
            return Physics2D.Raycast(startPosition, direction, _range, layerMask);
        }

        public void AddAmmo()
        {
            CurrentAmmo += _maxAmmo / 2;
            CurrentAmmo = Mathf.Clamp(CurrentAmmo, 0, _maxAmmo);
            Hud.OnAmmoCountUpdated.Invoke(GetAmmo());
        }

        public Sprite GetSprite()
        {
            return _characterSprite;
        }

        public Tuple<int, int> GetAmmo()
        {
            return new Tuple<int, int>(CurrentAmmo, _maxAmmo);
        }

        protected void SpawnEffect(Vector2 position)
        {
            GameObject.Instantiate(_effect, position, Quaternion.identity);
        }
    }
}
