using UnityEngine;

namespace Weapons
{
    [CreateAssetMenu(menuName = "Shooter/Create Weapon", fileName = "New Weapon", order = 0)]
    public class WeaponData : ScriptableObject
    {
        public int damage;
        public int maxAmmo;
        public float range;
        public Sprite characterSprite;
        public GameObject effect;
    }
}
