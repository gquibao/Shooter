using System;
using System.Collections.Generic;
using UnityEngine;
using Weapons;

public class PlayerStatus : MonoBehaviour
{
    public float life;
    public Melee meleeWeapon;

    [SerializeField] private WeaponData meleeData;
    [SerializeField] private SpriteRenderer spriteRenderer;
    
    public Weapon currentWeapon;

    private List<Weapon> _weaponsList;

    private void Start()
    {
        _weaponsList = new List<Weapon>();
        meleeWeapon = new Melee(meleeData);
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
        currentWeapon = _weaponsList[weaponIndex];
        spriteRenderer.sprite = currentWeapon.GetSprite();
        Debug.Log($"Trocou de arma para {weaponIndex}");
    }

    public void MeleeAttack(Vector2 direction)
    {
        meleeWeapon.Fire(transform.position, direction);
    }

    public void AddWeapon(Weapon weaponToAdd)
    {
        var weapon = _weaponsList.Find(weaponToCompare => weaponToCompare == weaponToAdd);
        if (weapon == null)
        {
            _weaponsList.Add(weaponToAdd);
        }
    }
}