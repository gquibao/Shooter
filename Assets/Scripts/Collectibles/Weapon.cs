using System;
using UnityEngine;
using Weapons;

namespace Collectibles
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private WeaponData weaponData;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            // var newWeapon = new Weapons.Weapon();
            // other.GetComponent<PlayerStatus>().AddWeapon();
        }
    }
}
