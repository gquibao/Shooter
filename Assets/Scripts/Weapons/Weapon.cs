using UnityEngine;

namespace Weapons
{
    public abstract class Weapon : IWeapon
    {
        protected float Damage;
        protected float Range;
        protected Sprite CharacterSprite;
        
        protected Weapon(WeaponData data)
        {
            Damage = data.damage;
            Range = data.range;
            CharacterSprite = data.characterSprite;
        }
        public void Fire(Vector2 startPosition, Vector2 direction)
        {
            
        }

        public Sprite GetSprite()
        {
            return CharacterSprite;
        }
    }
}
