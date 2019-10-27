using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public GameObject bulletPrefab;
    
    [SerializeField]
    public List<IWeapon> weapons = new List<IWeapon>();

    [SerializeField]
    private int currentWeapon;
    
    private void Start()
    {
        Debug.Log(weapons.Count);
        foreach (var w in weapons)
        {
            w.BulletPrefab = bulletPrefab;
        }
    }

    public void AddNewWeapon(IWeapon weapon)
    {
        if (weapons == null)
            weapons = new List<IWeapon>();
        weapons.Add(weapon);
    } 

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            weapons[currentWeapon].Shoot();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
            ChangeWeapon(0);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            ChangeWeapon(1);
    }

    private void ChangeWeapon(int weapon)
    {
        currentWeapon = weapon;
        UIController.Instance.UpdateWeaponImage(weapons[currentWeapon].Sprite);
    }

    public void RestoreAmmo(string weaponTag)
    {
        foreach (var w in weapons)
        {
            if (w.WeaponTag == weaponTag)
            {
                w.Restore();
                break;
            }
        }
    }
}
