using UnityEngine;

namespace Weapons
{
    public interface IWeapon
    {
        void Fire(Vector2 startPosition, Vector2 direction, LayerMask layerMask);
        void AddAmmo();
        Sprite GetSprite();
    }
}
