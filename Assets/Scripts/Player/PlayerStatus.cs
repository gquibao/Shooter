using System;
using System.Collections.Generic;
using Gameplay;
using UnityEngine;
using Weapons;
using Random = UnityEngine.Random;

namespace Player
{
    public class PlayerStatus : MonoBehaviour
    {
        public LayerMask attackLayerMask;
    
        private float _health;
        private const float MAXHealth = 100;
        private Melee _meleeWeapon;

        [SerializeField] private WeaponData meleeData;
        [SerializeField] private WeaponData revolverData;
        [SerializeField] private WeaponData smgData;
        [SerializeField] private WeaponData missileData;
        [SerializeField] private SpriteRenderer spriteRenderer;

        public Weapon CurrentWeapon;

        private List<Weapon> _weaponsList;

        private void Start()
        {
            _health = MAXHealth;
            _weaponsList = new List<Weapon>();
            _meleeWeapon = new Melee(meleeData);
            _weaponsList.Add(new Revolver(revolverData));
            _weaponsList.Add(new Smg(smgData));
            _weaponsList.Add(new MissileLauncher(missileData));
            SetCurrentWeapon(0);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1)) SetCurrentWeapon(0);
            if (Input.GetKeyDown(KeyCode.Alpha2)) SetCurrentWeapon(1);
            if (Input.GetKeyDown(KeyCode.Alpha3)) SetCurrentWeapon(2);
        }

        private void SetCurrentWeapon(int weaponIndex)
        {
            if (weaponIndex > _weaponsList.Count - 1) return;
            CurrentWeapon = _weaponsList[weaponIndex];
            spriteRenderer.sprite = CurrentWeapon.GetSprite();
            Hud.OnAmmoCountUpdated.Invoke(CurrentWeapon.GetAmmo());
        }

        public void MeleeAttack(Vector2 direction)
        {
            _meleeWeapon.Fire(transform.position, direction, attackLayerMask);
        }

        public void PickupAmmo()
        {
            CurrentWeapon.AddAmmo();
        }

        public void TakeDamage(float damageAmount)
        {
            _health -= damageAmount;
            Hud.OnHealthCountUpdated.Invoke(new Tuple<float, float>(_health, MAXHealth));
            if(_health <= 0) Hud.OnGameOver.Invoke();
        }
    }
}