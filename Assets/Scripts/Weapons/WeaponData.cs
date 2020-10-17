using UnityEngine;

namespace Weapons
{
    [CreateAssetMenu(menuName = "Shooter/Create Weapon", fileName = "New Weapon", order = 0)]
    public class WeaponData : ScriptableObject
    {
        public int damage;
        public float maxAmmo;
        public float reloadTime;
        public float range;
        public Sprite characterSprite;
    }
}
