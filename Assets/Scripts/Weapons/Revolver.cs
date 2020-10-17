using UnityEngine;

namespace Weapons
{
    public class Revolver : Weapon
    {
        public Revolver(WeaponData data) : base(data)
        {
            
        }

        public void Fire(Vector2 startPosition, Vector2 direction)
        {
            throw new System.NotImplementedException();
        }

        public Sprite GetSprite()
        {
            throw new System.NotImplementedException();
        }
    }
}
