﻿using System.Collections.Generic;
using UnityEngine;
using Weapons;
public class PlayerStatus : MonoBehaviour
{
    public float life;
    public Melee meleeWeapon;

    [SerializeField] private WeaponData meleeData;
    [SerializeField] private WeaponData revolverData;
    [SerializeField] private WeaponData smgData;
    [SerializeField] private WeaponData missileData;
    [SerializeField] private SpriteRenderer spriteRenderer;
    
    public Weapon currentWeapon;

    private List<Weapon> _weaponsList;

    private void Start()
    {
        _weaponsList = new List<Weapon>();
        meleeWeapon = new Melee(meleeData);
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
        currentWeapon = _weaponsList[weaponIndex];
        spriteRenderer.sprite = currentWeapon.GetSprite();
    }

    public void MeleeAttack(Vector2 direction)
    {
        meleeWeapon.Fire(transform.position, direction);
    }

    public void PickupAmmo()
    {
        var random = Random.Range(0, 3);
        _weaponsList[random].AddAmmo();
    }
}